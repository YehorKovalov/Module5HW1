using Newtonsoft.Json;

namespace APIPractice.Models
{
    public class ErrorResponse
    {
        [JsonProperty("error")]
        public string ErrorMessage { get; set; }
    }
}
