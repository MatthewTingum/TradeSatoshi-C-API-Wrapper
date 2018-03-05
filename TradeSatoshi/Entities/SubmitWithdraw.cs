using Newtonsoft.Json;

namespace TradeSatoshiAPI.Entities
{
    public partial class SubmitWithdrawEntity
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public object Message { get; set; }

        [JsonProperty("result")]
        public SubmitWithdraw Result { get; set; }
    }

    public partial class SubmitWithdraw
    {
        [JsonProperty("WithdrawalId")]
        public long WithdrawalId { get; set; }
    }
}
