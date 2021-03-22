using Hahn.ApplicationProcess.February2021.Data.HttpDataAccess._Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Data.HttpDataAccess
{
    public class CountryDataService : ICountryDataService
    {
        private readonly HttpClient _httpClient;

        public CountryDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> IsCountryValid(string countryname)
        {
            string baseUrl = "https://restcountries.eu/rest/v2/name/";
            string APIURL = $"{baseUrl}{countryname}?fullText=true";
            var response = await _httpClient.GetAsync(APIURL);
            if (response.IsSuccessStatusCode)
                return true;
            return false;
        }
    }
}
