using University.Info.HipolabsApi.Client.Responses;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace University.Info.HipolabsApi.Client.Interfaces
{
   public interface IHipolabsApiClient
   {
       Task <List<University.Info.HipolabsApi.Client.Responses.SearchResponse>> SearchByCountry(string country);

   }

}
