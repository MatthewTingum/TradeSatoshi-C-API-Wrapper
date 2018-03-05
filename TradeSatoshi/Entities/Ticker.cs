using Newtonsoft.Json;

namespace TradeSatoshiAPI.Entities
{
    public partial class TickerEntity
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public object Message { get; set; }

        [JsonProperty("result")]
        public Ticker Result { get; set; }
    }

    public partial class Ticker
    {
        [JsonProperty("bid")]
        public double Bid { get; set; }

        [JsonProperty("ask")]
        public double Ask { get; set; }

        [JsonProperty("last")]
        public double Last { get; set; }

        [JsonProperty("market")]
        public string Market { get; set; }
    }
}
