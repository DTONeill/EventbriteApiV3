using EventbriteApiV3.Model;
using System.Text.Json.Serialization;

namespace EventbriteApiV3.Events
{
    public class Event
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("category_id")]
        public string CategoryId { get; set; }
        [JsonPropertyName("subcategory_id")]
        public string SubCategoryId { get; set; }

        [JsonPropertyName("name")]
        public TextHtmlString Name { get; set; }

        [JsonPropertyName("description")]
        public TextHtmlString Description { get; set; }

        [JsonPropertyName("summary")]
        public string Summary { get; set; }

        [JsonPropertyName("long_description")]
        public TextHtmlString LongDescription { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("start")]
        public MultipartDate Start { get; set; }

        [JsonPropertyName("end")]
        public MultipartDate End { get; set; }

        [JsonPropertyName("is_free")]
        public bool IsFree { get; set; }

        [JsonPropertyName("logo")]
        public Logo Logo { get; set; }

        /// <summary>
        /// location/ venue reference
        /// </summary>
        [JsonPropertyName("venue_id")]
        internal string VenueId { get; set; }

        [JsonPropertyName("venue")]
        public Venue Venue { get; set; }

        /// <summary>
        /// true if the event is online only
        /// </summary>
        [JsonPropertyName("online_event")]
        public bool? OnlineEvent { get; set; }
    }
}