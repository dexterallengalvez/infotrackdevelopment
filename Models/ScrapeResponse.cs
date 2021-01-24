using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoTrackDevelopmentProject.Models
{
    public class ScrapeResponse
    {
        public ScrapeResponse()
        {
            Indexes = new List<int>();
        }

        /// <summary>
        /// The target search engine for scraping
        /// </summary>
        public string SearchEngine { get; set; }
        
        /// <summary>
        /// The indexes that the keyword appeared in
        /// </summary>
        public List<int> Indexes { get; set; }
    }
}
