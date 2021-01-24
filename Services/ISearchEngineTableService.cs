using InfoTrackDevelopmentProject.Models;
using System.Collections.Generic;

namespace InfoTrackDevelopmentProject.Services
{
    public interface ISearchEngineTableService
    {
        List<SearchEngine> GetSearchEngines();
    }
}