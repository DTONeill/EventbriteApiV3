using Newtonsoft.Json;

namespace EventbriteApiV3.Model
{
    public class Pagination
    {
        [JsonProperty("page_number")]
        public int PageNumber { get; set; }

        [JsonProperty("page_count")]
        public int PageCount { get; set; }

        [JsonProperty("object_count")]
        public int TotalCount { get; set; }
    }
}