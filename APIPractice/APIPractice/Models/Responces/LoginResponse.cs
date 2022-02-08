using Newtonsoft.Json;

namespace APIPractice.Models.Responces
{
    public class LoginResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
