using System.Collections.Generic;
using University.Info.Domain;
using University.Info.Interfaces.Application;

namespace University.Info.Application
{
    public class UniversityInformationRetriever : IUniversityInformationRetriever
    {
        public List<UniversityInformation> GetUniversityInformationByCountry(string countryName)
        {
            var universityInformation = new List<UniversityInformation>();

           //TODO:  Implement this function 
           return universityInformation;

        }
    }
}
