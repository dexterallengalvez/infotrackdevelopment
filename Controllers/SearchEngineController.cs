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
    /// Controller for the Search Engines involved in the project
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class SearchEngineController : ControllerBase
    {
        /// <summary>
        /// Search Engine Table Service -> Used for retrieving the list of search engines
        /// </summary>
        protected ISearchEngineTableService searchEngineTableService;

        /// <summary>
        /// Search Engine Controller Constructor
        /// </summary>
        /// <param name="searchEngineTableService"></param>
        public SearchEngineController(ISearchEngineTableService searchEngineTableService)
        {
            this.searchEngineTableService = searchEngineTableService;
        }
        /// <summary>
        /// Retrieve the list of Search Engine from a database source
        /// --In this instance, the list of search engines are retrieved from an Azure Table Storage
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<SearchEngine> Get()
        {
            return searchEngineTableService.GetSearchEngines();
        }
    }
}
