using System.Collections.Generic;
using EventbriteApiV3.Model;
using Newtonsoft.Json;

namespace EventbriteApiV3.Events
{
    public class EventsSearchApiResponse : BaseApiResponse
    {
        [JsonProperty("events")]
        public List<Event> Events { get; set; }
    }
}