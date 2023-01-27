using University.Info.HipolabsApi.Client.Interfaces;
using University.Info.HipolabsApi.Client.Responses;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Configuration;
using Newtonsoft.Json;

namespace University.Info.HipolabsApi.Client
{

   public class HipolabsApiClient : IHipolabsApiClient
    {
        /// <summary>
        /// Search by country name
        /// </summary>
        /// <param name="country">The country </param>
        /// <returns></returns>
        public async Task<List<Client.Responses.SearchResponse>>  SearchByCountry(string country)
        {
            HttpClient client = new HttpClient();
            string urlCountry = country.Replace(" ", "+");
            Console.WriteLine(urlCountry);

            var universityUrl = ConfigurationSettings.AppSettings.Get("ApiUrl");

            string url = $"http://universities.hipolabs.com/search?country={urlCountry}";
            string rawdata = await client.GetStringAsync(url);
            this.Response = JsonConvert.DeserializeObject<List<Client.Responses.SearchResponse>>(rawdata);
            
            return this.Response;
        }
        
        List<Client.Responses.SearchResponse> Response;
    }

}
