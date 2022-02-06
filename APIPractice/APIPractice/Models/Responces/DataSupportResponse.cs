using System.Text.Json.Serialization;

namespace APIPractice.Models.Responces
{
    public class DataSupportResponse<T>
    {
        [JsonPropertyName("data")]
        public T Data { get; set; }
        [JsonPropertyName("support")]
        public Support Support { get; set; }
    }
}
