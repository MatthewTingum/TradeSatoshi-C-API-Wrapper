using Newtonsoft.Json;

namespace TradeSatoshiAPI.Entities
{
    public partial class DepositsEntity
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public object Message { get; set; }

        [JsonProperty("result")]
        public Deposit[] Result { get; set; }
    }

    public partial class Deposit
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Currency")]
        public string Currency { get; set; }

        [JsonProperty("CurrencyLong")]
        public string CurrencyLong { get; set; }

        [JsonProperty("Amount")]
        public double Amount { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("Txid")]
        public string Txid { get; set; }

        [JsonProperty("Confirmations")]
        public long Confirmations { get; set; }

        [JsonProperty("Timestamp")]
        public System.DateTimeOffset Timestamp { get; set; }
    }
}
