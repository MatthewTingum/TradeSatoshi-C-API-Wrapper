using Newtonsoft.Json;

namespace TradeSatoshiAPI.Entities
{


    public partial class CurrencyListEntity
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public object Message { get; set; }

        [JsonProperty("result")]
        public CurrencyList[] Result { get; set; }
    }

    public partial class CurrencyList
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("currencyLong")]
        public string CurrencyLong { get; set; }

        [JsonProperty("minConfirmation")]
        public long MinConfirmation { get; set; }

        [JsonProperty("txFee")]
        public double TxFee { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

}
