using Newtonsoft.Json;

namespace TradeSatoshiAPI.Entities
{
    public partial class BalancesEntity
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public object Message { get; set; }

        [JsonProperty("result")]
        public Balance[] Result { get; set; }
    }
 
}
