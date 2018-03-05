using Newtonsoft.Json;

namespace TradeSatoshiAPI.Entities
{
    public partial class TransferEntity
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public object Message { get; set; }

        [JsonProperty("result")]
        public Transfer Result { get; set; }
    }

    public partial class Transfer
    {
        [JsonProperty("data")]
        public string Data { get; set; }
    }
}
