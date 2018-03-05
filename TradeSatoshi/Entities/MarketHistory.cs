using Newtonsoft.Json;

namespace TradeSatoshiAPI.Entities
{
    public partial class MarketHistoryEntity
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public object Message { get; set; }

        [JsonProperty("result")]
        public MarketHistory[] Result { get; set; }
    }

    public partial class MarketHistory
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("timeStamp")]
        public System.DateTimeOffset TimeStamp { get; set; }

        [JsonProperty("quantity")]
        public double Quantity { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("orderType")]
        public string OrderType { get; set; }

        [JsonProperty("total")]
        public double Total { get; set; }
    }
}
