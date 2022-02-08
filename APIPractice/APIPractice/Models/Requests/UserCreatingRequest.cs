using System;
using Newtonsoft.Json;

namespace APIPractice.Models.Requests
{
    public class UserCreatingRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("job")]
        public string Job { get; set; }
    }
}
