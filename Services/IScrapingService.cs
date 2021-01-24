using InfoTrackDevelopmentProject.Models;
using System.Threading.Tasks;

namespace InfoTrackDevelopmentProject.Services
{
    public interface IScrapingService
    {
        Task<ScrapeResponse> ScrapePage(ScrapeRequest scrapeRequest);
    }
}