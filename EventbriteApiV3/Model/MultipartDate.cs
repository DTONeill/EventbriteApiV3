using System;
using Newtonsoft.Json;

namespace EventbriteApiV3.Model
{
    public class MultipartDate
    {
        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("utc")]
        public DateTime Utc { get; set; }

        [JsonProperty("local")]
        public DateTime Local { get; set; }
    }
}