using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using University.Info.Domain;
using University.Info.Interfaces.Application;
using University.Info.Interfaces.Repository;

namespace University.Info.Application
{
    public class UniversityInformationRetriever : IUniversityInformationRetriever
    {
        private readonly IUniversityInformationProvider _universityInformationProvider;

        public UniversityInformationRetriever(IUniversityInformationProvider universityInformationProvider)
        {
            _universityInformationProvider = universityInformationProvider ?? throw new ArgumentException(nameof(universityInformationProvider));
        }

        public async Task<List<UniversityInformation>> GetUniversityInformationByCountry(string countryName)
        {
            var universityInformation = new List<UniversityInformation>();
            var universityList =  await _universityInformationProvider.GetUniversityInformationByCountry(countryName).ConfigureAwait(false);
            return universityList;


        }
    }
}
