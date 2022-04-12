using System.Text.Json.Serialization;

namespace EventbriteApiV3.Model
{
    public class TextHtmlString
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("html")]
        public string Html { get; set; }
    }
}