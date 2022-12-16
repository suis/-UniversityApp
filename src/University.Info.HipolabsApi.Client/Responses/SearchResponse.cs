using System.Collections.Generic;
using Newtonsoft.Json;

namespace University.Info.HipolabsApi.Client.Responses
{
   public class SearchResponse
    {
        public string alpha_two_code { get; set; }
        public string name { get; set; }
        public List<string> web_pages { get; set; }

        [JsonProperty("state-province")]
        public object stateprovince { get; set; }
        public List<string> domains { get; set; }
        public string country { get; set; }

    }
}
