using Newtonsoft.Json;

namespace TradeSatoshiAPI.Entities
{

    public partial class OrderBookEntity
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public object Message { get; set; }

        [JsonProperty("result")]
        public OrderBook Result { get; set; }
    }

    public partial class OrderBook
    {
        [JsonProperty("buy")]
        public Buy[] Buy { get; set; }

        [JsonProperty("sell")]
        public Sell[] Sell { get; set; }
    }

    public partial class Buy
    {
        [JsonProperty("quantity")]
        public double Quantity { get; set; }

        [JsonProperty("rate")]
        public double Rate { get; set; }
    }

    public partial class Sell
    {
        [JsonProperty("quantity")]
        public double Quantity { get; set; }

        [JsonProperty("rate")]
        public double Rate { get; set; }
    }


}
