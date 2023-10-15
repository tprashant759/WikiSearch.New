//using WikiSearch.Models;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WikiSearch.API
{
    public class WikiService : IWikiService
    {
        static HttpClient client = new HttpClient();
        
        public async Task<List<WikiEntries>> GetWikiEntriesList()
        {
            List<WikiEntries> wikiList = null;
            HttpResponseMessage response = await client.GetAsync(Constants.WikiListGet);
            if (response.IsSuccessStatusCode)
            {
                wikiList = await response.Content.ReadAsAsync<List<WikiEntries>>();
            }

            return wikiList;
        }

        public async Task<WikiEntries> GetWikiDetails(Int32 wikiId)
        {
        
        }
    }
}