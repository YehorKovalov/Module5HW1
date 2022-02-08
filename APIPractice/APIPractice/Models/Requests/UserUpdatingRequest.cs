using System;
using Newtonsoft.Json;

namespace APIPractice.Models.Requests
{
    public class UserUpdatingRequest
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("job")]
        public string Job { get; set; }
    }
}
