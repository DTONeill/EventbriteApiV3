using Newtonsoft.Json;

namespace EventbriteApiV3.Model
{
    public class TextHtmlString
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("html")]
        public string Html { get; set; }
    }
}