using Newtonsoft.Json;

namespace TradeSatoshiAPI.Entities
{
    public partial class CancelOrderEntity
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public object Message { get; set; }

        [JsonProperty("result")]
        public CancelOrder Result { get; set; }
    }

    public partial class CancelOrder
    {
        [JsonProperty("CanceledOrders")]
        public long[] CanceledOrders { get; set; }
    }
}
