using University.Info.HipolabsApi.Client.Responses;

namespace University.Info.HipolabsApi.Client.Interfaces
{
   public interface IHipolabsApiClient
   {
       SearchResponse SearchByCountry(string country);

   }

}
