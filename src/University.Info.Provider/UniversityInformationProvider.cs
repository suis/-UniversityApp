using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Info.Domain;
using University.Info.HipolabsApi.Client;
using University.Info.HipolabsApi.Client.Interfaces;
using University.Info.Interfaces.Repository;

namespace University.Info.Repository
{
    public class UniversityInformationProvider : IUniversityInformationProvider
    {
        private readonly IHipolabsApiClient _hipolabsApiClient;

        public UniversityInformationProvider(IHipolabsApiClient hipolabsApiClient)
        {
            _hipolabsApiClient = hipolabsApiClient ?? throw new ArgumentNullException(nameof(hipolabsApiClient));
        }

        public async Task<List<UniversityInformation>> GetUniversityInformationByCountry(string countryName)
        {
            var response = await _hipolabsApiClient.SearchByCountry("France").ConfigureAwait(false);

            var universityInformationList = response
                .Select(x => new UniversityInformation() { UniversityName= x.name })
                .ToList();

            return universityInformationList;
        }
    }
}
