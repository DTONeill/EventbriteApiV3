using System.Text.Json.Serialization;

namespace EventbriteApiV3.Model
{
    public class Pagination
    {
        [JsonPropertyName("page_number")]
        public int PageNumber { get; set; }

        [JsonPropertyName("page_count")]
        public int PageCount { get; set; }

        [JsonPropertyName("object_count")]
        public int TotalCount { get; set; }
    }
}