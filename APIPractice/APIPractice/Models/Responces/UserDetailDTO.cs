using System;
using Newtonsoft.Json;

namespace APIPractice.Models.Responces
{
    public class UserDetailDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("job")]
        public string Job { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreationTime { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatingTime { get; set; }
    }
}
