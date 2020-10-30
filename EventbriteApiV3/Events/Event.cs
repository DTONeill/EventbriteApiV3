using EventbriteApiV3.Model;
using Newtonsoft.Json;

namespace EventbriteApiV3.Events
{
    public class Event
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("category_id")]
        public int? CategoryId { get; set; }
        [JsonProperty("name")]
        public TextHtmlString Name { get; set; }

        [JsonProperty("description")]
        public TextHtmlString Description { get; set; }

        [JsonProperty("long_description")]
        public TextHtmlString LongDescription { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("start")]
        public MultipartDate Start { get; set; }

        [JsonProperty("end")]
        public MultipartDate End { get; set; }

        [JsonProperty("is_free")]
        public string IsFree { get; set; }

        [JsonProperty("logo")]
        public Logo Logo { get; set; }
    }
}