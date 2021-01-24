using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using InfoTrackDevelopmentProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace InfoTrackDevelopmentProject.Services
{
    /// <summary>
    /// Scraping service - manually created for now but 3rd party libraries may be used in the future
    /// </summary>
    public class ScrapingService : IScrapingService
    {
        private HttpClient httpClient;
        private HtmlParser htmlParser;

        /// <summary>
        /// ScrapingService default constructor
        /// </summary>
        public ScrapingService()
        {
            httpClient = new HttpClient();
            htmlParser = new HtmlParser();
        }

        /// <summary>
        /// Scrapes the page and returns the number of occurences of the keyword in any cite tag
        /// </summary>
        /// <param name="scrapeRequest"></param>
        /// <returns></returns>
        public async Task<ScrapeResponse> ScrapePage(ScrapeRequest scrapeRequest)
        {
            List<string> searchResults = new List<string>();

            //For each page, get the list of links in the results
            for (int i = 1; i <= int.Parse(scrapeRequest.Pages); i++)
            {
                IHtmlDocument document = await ExecuteSearch($"{scrapeRequest.Url}/Page{i:00}.html");
                searchResults.AddRange(GetSearchResultItems(document, scrapeRequest.SearchEngine));
            }

            //Get the indexes of the keyword
            List<int> keywordIndexes = searchResults?.Select((item, index) => new SearchResult() { Item = item, Index = index})
                                                        .Where(x => x.Item.ToLower().Contains(scrapeRequest.Keyword.ToLower()))
                                                        .Select(x => x.Index + 1)
                                                        .ToList();

            return new ScrapeResponse()
            {
                SearchEngine = scrapeRequest.SearchEngine,
                Indexes = keywordIndexes
            };
        }

        /// <summary>
        /// Retrieves the search results for a particular Html Document
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        private static List<string> GetSearchResultItems(IHtmlDocument document, string searchEngine)
        {
            switch (searchEngine)
            {
                case Constants.Constants.Bing:
                    {
                        //Retrieve all the search results for Bing
                        return document.All.Where(x => x.Id == "b_results").First().Children
                                                                .Where(x => x.ClassName == "b_algo")
                                                                .Select(x => x.FindDescendant<IHtmlAnchorElement>().Origin)
                                                                .ToList();
                    }
                case Constants.Constants.Google:
                    {
                        //Retrieve all the search results for Bing
                        return document.All.Where(x => x.ClassName == "TbwUpd NJjxre")
                                                .Select(x => x.FirstChild.TextContent)
                                                .ToList();
                    }
                default: return null;
            }
            
        }

        /// <summary>
        /// Downloads the content of a web page and transforms it into an Html Document
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        private async Task<IHtmlDocument> ExecuteSearch(string Url)
        {
            if (String.IsNullOrEmpty(Url)) throw new Exception("Please provide a valid Url");
            //Prepare the request
            CancellationTokenSource cancellationToken = new CancellationTokenSource();
            HttpResponseMessage request = await httpClient.GetAsync(Url);
            cancellationToken.Token.ThrowIfCancellationRequested();

            //Retrieve the page content
            Stream response = await request.Content.ReadAsStreamAsync();
            cancellationToken.Token.ThrowIfCancellationRequested();
            return htmlParser.ParseDocument(response);
        }
    }
}
