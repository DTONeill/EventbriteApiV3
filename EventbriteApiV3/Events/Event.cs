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

        [JsonProperty("summary")]
        public string Summary { get; set; }

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

        /// <summary>
        /// location/ venue reference
        /// </summary>
        [JsonProperty("venue_id")]
        internal long? VenueId { get; set; }

        [JsonProperty("venue")]
        public Venue Venue { get; set; }

        /// <summary>
        /// true if the event is online only
        /// </summary>
        [JsonProperty("online_event")]
        public bool? OnlineEvent { get; set; }
    }
}