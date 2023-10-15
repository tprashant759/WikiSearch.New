using WikiSearch.Models;

namespace WikiSearch.API
{
    public interface IWikiService
    {
        Task<List<WikiEntries>> GetWikiEntriesList();
        Task<WikiEntries> GetWikiDetails(int wikiId);
    }
}