using Newtonsoft.Json;

namespace APIPractice.Models
{
    public class SupportDTO
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
