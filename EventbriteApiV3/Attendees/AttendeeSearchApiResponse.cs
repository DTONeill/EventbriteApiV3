using System.Collections.Generic;
using EventbriteApiV3.Model;
using System.Text.Json.Serialization;

namespace EventbriteApiV3.Attendees
{
    public class AttendeeSearchApiResponse : BaseApiResponse
    {
        [JsonPropertyName("attendees")]
        public ICollection<Attendee> Attendees { get; set; }
    }
}