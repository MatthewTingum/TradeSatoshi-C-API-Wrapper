using Newtonsoft.Json;

namespace TradeSatoshiAPI.Entities
{
    public partial class GenerateAddressEntity
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public object Message { get; set; }

        [JsonProperty("result")]
        public GenerateAddress Result { get; set; }
    }

    public partial class GenerateAddress
    {
        [JsonProperty("Currency")]
        public string Currency { get; set; }

        [JsonProperty("Address")]
        public string Address { get; set; }
    }
}
