using System;
using System.Text.Json.Serialization;

namespace EventbriteApiV3.Model
{
    public class MultipartDate
    {
        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }

        [JsonPropertyName("utc")]
        public DateTime Utc { get; set; }

        [JsonPropertyName("local")]
        public DateTime Local { get; set; }
    }
}