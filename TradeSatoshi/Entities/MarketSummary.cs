using Newtonsoft.Json;

namespace TradeSatoshiAPI.Entities
{
    public partial class MarketSummaryEntity
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public object Message { get; set; }

        [JsonProperty("result")]
        public MarketSummary Result { get; set; }
    }

    public partial class MarketSummary
    {
        [JsonProperty("market")]
        public string Market { get; set; }

        [JsonProperty("high")]
        public double High { get; set; }

        [JsonProperty("low")]
        public double Low { get; set; }

        [JsonProperty("volume")]
        public double Volume { get; set; }

        [JsonProperty("baseVolume")]
        public double BaseVolume { get; set; }

        [JsonProperty("last")]
        public double Last { get; set; }

        [JsonProperty("bid")]
        public double Bid { get; set; }

        [JsonProperty("ask")]
        public double Ask { get; set; }

        [JsonProperty("openBuyOrders")]
        public long OpenBuyOrders { get; set; }

        [JsonProperty("openSellOrders")]
        public long OpenSellOrders { get; set; }
    }

}
