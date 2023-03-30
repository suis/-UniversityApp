using University.Info.Domain;
using University.Info.HipolabsApi.Client.Interfaces;
using University.Info.Interfaces.Repository;
using University.Info.Repository;

namespace UniversityInfo.Tests
{
    public class UniversityInfoProvTests
    {
        [Fact]
        public async Task SearchViaCountryReturnsList()
        {
            var client = new TestHipolabsApiClient(new List<University.Info.HipolabsApi.Client.Responses.SearchResponse>()
            {
               new University.Info.HipolabsApi.Client.Responses.SearchResponse()
               {
                   name="University of Paris",
               }

            });
            var Provider = new UniversityInformationProvider(client);
            var result = await Provider.GetUniversityInformationByCountry("France");
            Assert.NotNull(result);
            Assert.Equal("University of Paris", result.First().UniversityName);
        }
    }


    public class TestHipolabsApiClient : IHipolabsApiClient
    {
        private readonly List<University.Info.HipolabsApi.Client.Responses.SearchResponse> _response;

        public TestHipolabsApiClient(List<University.Info.HipolabsApi.Client.Responses.SearchResponse> response)
        {
            _response = response ?? throw new ArgumentNullException(nameof(response));
        }

        public async Task<List<University.Info.HipolabsApi.Client.Responses.SearchResponse>> SearchByCountry(string countryName)
        {
            return await Task.FromResult(_response);
        }
    }
}