using System.Collections.Generic;
using EventbriteApiV3.Model;
using System.Text.Json.Serialization;

namespace EventbriteApiV3.Events
{
    public class EventsSearchApiResponse : BaseApiResponse
    {
        [JsonPropertyName("events")]
        public List<Event> Events { get; set; }
    }
}