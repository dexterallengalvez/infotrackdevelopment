using InfoTrackDevelopmentProject.Models;
using InfoTrackDevelopmentProject.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoTrackDevelopmentProject.Controllers
{
    /// <summary>
    /// Controller for the Scraping Service
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ScraperController : ControllerBase
    {
        private IScrapingService scrapingService;

        public ScraperController(IScrapingService scrapingService)
        {
            this.scrapingService = scrapingService;
        }

        /// <summary>
        /// Execute the web scraping for a particular url
        /// </summary>
        /// <param name="scrapeRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ScrapeResponse> Post([FromBody]ScrapeRequest scrapeRequest)
        {
            return await scrapingService.ScrapePage(scrapeRequest);
        }
    }
}
