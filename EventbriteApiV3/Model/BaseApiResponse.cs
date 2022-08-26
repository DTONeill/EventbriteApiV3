using System.Text.Json.Serialization;

namespace EventbriteApiV3.Model
{
    public abstract class BaseApiResponse
    {
        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; }
    }
}
