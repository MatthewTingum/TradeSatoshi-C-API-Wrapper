using Newtonsoft.Json;

namespace TradeSatoshiAPI.Entities
{
    public partial class TradePairChart
    {
        [JsonProperty("Candle")]
        public double[][] Candle { get; set; }

        [JsonProperty("Volume")]
        public double[][] Volume { get; set; }

        [JsonProperty("Low")]
        public double Low { get; set; }

        [JsonProperty("High")]
        public double High { get; set; }

        [JsonProperty("Last")]
        public double Last { get; set; }
    }
}
