using System.Text.Json.Serialization;

namespace EventbriteApiV3.Attendees
{
    public class Question
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("required")]
        public bool Required { get; set; }
    }
}