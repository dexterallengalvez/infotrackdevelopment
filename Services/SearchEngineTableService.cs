using InfoTrackDevelopmentProject.Models;
using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoTrackDevelopmentProject.Services
{
    /// <summary>
    /// Service class for Search Engines
    /// </summary>
    public class SearchEngineTableService : TableStorageService, ISearchEngineTableService
    {
        /// <summary>
        /// Cloud Table object for getting the Azure Table reference
        /// </summary>
        protected CloudTable searchEngineTable;

        /// <summary>
        /// Default public constructor for Search Engine Service
        /// </summary>
        /// <param name="accountName"></param>
        /// <param name="key"></param>
        /// <param name="tableName"></param>
        public SearchEngineTableService(string accountName, string key, string tableName) : base(accountName, key)
        {
            if (String.IsNullOrEmpty(accountName) || String.IsNullOrEmpty(key) || String.IsNullOrEmpty(tableName))
                throw new Exception("Invalid parameters. Cannot create search engine table");

            searchEngineTable = this.tableClient.GetTableReference(tableName);
        }

        /// <summary>
        /// Retrieves the list of Search Engines
        /// </summary>
        /// <returns></returns>
        public List<SearchEngine> GetSearchEngines()
        {
            return searchEngineTable.ExecuteQuery(new TableQuery<SearchEngine>())
                .ToList();
        }
    }
}
