using Newtonsoft.Json;

namespace APIPractice.Models.Responces
{
    public class ErrorResponse
    {
        [JsonProperty("error")]
        public string ErrorMessage { get; set; }
    }
}
