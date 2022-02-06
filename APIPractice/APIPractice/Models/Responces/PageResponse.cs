using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace APIPractice.Models.Responces
{
    public class PageResponse<T>
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("per_page")]
        public int PerPage { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("data")]
        public T Data { get; set; }
    }
}
