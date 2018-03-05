using Newtonsoft.Json;

namespace TradeSatoshiAPI.Entities
{
    public partial class OrdersEntity
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public object Message { get; set; }

        [JsonProperty("result")]
        public Order[] Result { get; set; }
    }

}
