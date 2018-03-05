using Newtonsoft.Json;

namespace TradeSatoshiAPI.Entities
{
    public partial class SubmitOrderEntity
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public object Message { get; set; }

        [JsonProperty("result")]
        public SubmitOrder Result { get; set; }
    }

    public partial class SubmitOrder
    {
        [JsonProperty("OrderId")]
        public long OrderId { get; set; }

        [JsonProperty("Filled")]
        public long[] Filled { get; set; }
    }
}
