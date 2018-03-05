using Newtonsoft.Json;

namespace TradeSatoshiAPI.Entities
{
    public partial class MarketSummariesEntity
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public object Message { get; set; }

        [JsonProperty("result")]
        public MarketSummary[] Result { get; set; }
    }

}
