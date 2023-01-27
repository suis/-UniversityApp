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
        public async Task<List<UniversityInformation>> GetUniversityInformationByCountry(string countryName)
        {
            IHipolabsApiClient client = new HipolabsApiClient();
            var response = await client.SearchByCountry("France").ConfigureAwait(false);

            var universityInformationList = response
                .Select(x => new UniversityInformation() { UniversityName= x.name })
                .ToList();

            return universityInformationList;
        }
    }
}
