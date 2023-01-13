using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using University.Info.HipolabsApi;
using University.Info.HipolabsApi.Client;
using University.Info.HipolabsApi.Client.Interfaces;

namespace University.Info.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IHipolabsApiClient client = new HipolabsApiClient();
            List<HipolabsApi.Client.Responses.SearchResponse> response =  await client.SearchByCountry("France");
            Console.WriteLine(response[1].name);
        }
    }
}
