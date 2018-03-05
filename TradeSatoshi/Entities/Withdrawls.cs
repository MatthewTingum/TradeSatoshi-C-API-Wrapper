using Newtonsoft.Json;

namespace TradeSatoshiAPI.Entities
{
    public partial class WithdrawlsEntity
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public object Message { get; set; }

        [JsonProperty("result")]
        public Withdrawl[] Result { get; set; }
    }

    public partial class Withdrawl
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Currency")]
        public string Currency { get; set; }

        [JsonProperty("CurrencyLong")]
        public string CurrencyLong { get; set; }

        [JsonProperty("Amount")]
        public double Amount { get; set; }

        [JsonProperty("Fee")]
        public double Fee { get; set; }

        [JsonProperty("Address")]
        public string Address { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("Txid")]
        public string Txid { get; set; }

        [JsonProperty("Confirmations")]
        public long Confirmations { get; set; }

        [JsonProperty("Timestamp")]
        public System.DateTimeOffset Timestamp { get; set; }

        [JsonProperty("IsApi")]
        public bool IsApi { get; set; }
    }
}
