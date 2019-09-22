using Newtonsoft.Json;

namespace EventbriteApiV3.Attendees
{
    public class Question
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("required")]
        public bool Required { get; set; }
    }
}