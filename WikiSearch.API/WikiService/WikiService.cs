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
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public class WikiService : IWikiService
    {
        static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public async Task<List<WikiEntries>> GetWikiEntriesList(string searchText)
        {
            List<WikiEntries> wikiList = null;
            HttpResponseMessage response = await client.GetAsync(string.Format(Constants.WikiAPI,searchText));
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                wikiList =new List<WikiEntries> { JsonConvert.DeserializeObject<WikiEntries>(content) };
            }

            return wikiList;
        }
    }
}