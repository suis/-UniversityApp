using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using University.Info.Application;
using University.Info.HipolabsApi;
using University.Info.HipolabsApi.Client;
using University.Info.HipolabsApi.Client.Interfaces;
using University.Info.Interfaces.Application;
using University.Info.Interfaces.Repository;
using University.Info.Repository;

namespace University.Info.ConsoleApp
{
    public class Program
    {

        
        static async Task Main(string[] args)
        {

            var serviceProvider = new ServiceCollection()
                .AddSingleton<IUniversityInformationRetriever, UniversityInformationRetriever>()
                .AddSingleton<IUniversityInformationProvider, UniversityInformationProvider>()
                .BuildServiceProvider();

            
             var universityInformationRetriever = serviceProvider.GetService<IUniversityInformationRetriever>();

             var universities = universityInformationRetriever.GetUniversityInformationByCountry("France");

             Console.WriteLine(universities.Result[0].UniversityName);

        }
    }
}
