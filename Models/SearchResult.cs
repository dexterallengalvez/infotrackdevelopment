using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoTrackDevelopmentProject.Models
{
    /// <summary>
    /// Indicates the search result and when it appeared in the search result
    /// </summary>
    public class SearchResult
    {
        /// <summary>
        /// The link / item in the search result
        /// </summary>
        public string Item { get; set; }

        /// <summary>
        /// The index where the item appeared in the search result
        /// </summary>
        public int Index { get; set; }
    }
}
