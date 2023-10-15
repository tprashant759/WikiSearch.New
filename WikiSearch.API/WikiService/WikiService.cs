//using WikiSearch.Models;

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WikiSearch.Models;

namespace WikiSearch.API
{
    public class WikiService : IWikiService
    {
        static readonly HttpClient client = new HttpClient();
        
        public async Task<List<WikiEntries>> GetWikiEntriesList(string searchText)
        {
            List<WikiEntries> wikiList = null;
            HttpResponseMessage response = await client.GetAsync(Constants.WikiListGet);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                wikiList = JsonConvert.DeserializeObject<List<WikiEntries>>(content);
            }

            return wikiList;
        }

        public async Task<WikiEntries> GetWikiDetails(Int32 wikiId)
        {
            return null;
        }
    }
}