using System.Collections.Generic;
using System.Threading.Tasks;
using WikiSearch.Models;

namespace WikiSearch.API
{
    public interface IWikiService
    {
        Task<List<WikiEntries>> GetWikiEntriesList(string searchText);
        Task<WikiEntries> GetWikiDetails(int wikiId);
    }
    
    
}