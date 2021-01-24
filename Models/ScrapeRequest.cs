using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoTrackDevelopmentProject.Models
{
    /// <summary>
    /// Represents a request for web scraping
    /// </summary>
    public class ScrapeRequest
    {
        /// <summary>
        /// The target search engine
        /// </summary>
        public string SearchEngine { get; set; }
        
        /// <summary>
        /// The Url for scraping
        /// </summary>
        public string Url { get; set; }
        
        /// <summary>
        /// The keyword to be searched
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        /// The number of pages to search
        /// </summary>
        public string Pages { get; set; }
    }
}
