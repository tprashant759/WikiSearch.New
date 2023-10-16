using System.Collections.Generic;
using System.Threading.Tasks;
using WikiSearch.Models;

namespace WikiSearch.API
{
    /// <summary>
    /// WikiService for API calls
    /// </summary>
    public interface IWikiService
    {
        /// <summary>
        /// Get list of wikipedia entries based on search text
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        Task<List<WikiEntries>> GetWikiEntriesList(string searchText);
    }
}