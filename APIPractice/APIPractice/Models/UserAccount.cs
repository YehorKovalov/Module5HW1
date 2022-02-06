using Newtonsoft.Json;

namespace APIPractice.Models
{
    public class UserAccount
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }
}