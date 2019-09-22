using System.Collections.Generic;
using EventbriteApiV3.Model;
using Newtonsoft.Json;

namespace EventbriteApiV3.Attendees
{
    public class AttendeeSearchApiResponse : BaseApiResponse
    {
        [JsonProperty("attendees")]
        public List<Attendee> Attendees { get; set; }
    }
}