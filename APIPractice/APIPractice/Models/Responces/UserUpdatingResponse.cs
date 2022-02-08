using System;
using Newtonsoft.Json;

namespace APIPractice.Models.Responces
{
    public class UserUpdatingResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("job")]
        public string Job { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatingTime { get; set; }
    }
}
