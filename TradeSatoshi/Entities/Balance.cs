using Newtonsoft.Json;

namespace TradeSatoshiAPI.Entities
{
    public partial class BalanceEntity
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public object Message { get; set; }

        [JsonProperty("result")]
        public Balance Result { get; set; }
    }

    public partial class Balance
    {
        [JsonProperty("Currency")]
        public string Currency { get; set; }

        [JsonProperty("CurrencyLong")]
        public string CurrencyLong { get; set; }

        [JsonProperty("Avaliable")]
        public double Avaliable { get; set; }

        [JsonProperty("Total")]
        public double Total { get; set; }

        [JsonProperty("HeldForTrades")]
        public double HeldForTrades { get; set; }

        [JsonProperty("Unconfirmed")]
        public double Unconfirmed { get; set; }

        [JsonProperty("PendingWithdraw")]
        public double PendingWithdraw { get; set; }

        [JsonProperty("Address")]
        public string Address { get; set; }
    }
}
