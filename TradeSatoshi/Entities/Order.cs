using Newtonsoft.Json;

namespace TradeSatoshiAPI.Entities
{
    public partial class OrderEntity
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public object Message { get; set; }

        [JsonProperty("result")]
        public Order Result { get; set; }
    }

    public partial class Order
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Market")]
        public string Market { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Amount")]
        public double Amount { get; set; }

        [JsonProperty("Rate")]
        public double Rate { get; set; }

        [JsonProperty("Remaining")]
        public double Remaining { get; set; }

        [JsonProperty("Total")]
        public double Total { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("Timestamp")]
        public System.DateTimeOffset Timestamp { get; set; }

        [JsonProperty("IsApi")]
        public bool IsApi { get; set; }
    }
}
