using System.Collections.Generic;
using Newtonsoft.Json;

namespace EventbriteApiV3.Attendees
{
    public class Attendee
    {
        [JsonProperty("id")]
        public double Id { get; set; }

        [JsonProperty("ticket_class_id")]
        public string TicketClassId { get; set; }

        [JsonProperty("ticket_class_name")]
        public string TicketClassName { get; set; }

        [JsonProperty("profile")]
        public Profile Profile { get; set; }

        [JsonProperty("questions")]
        public List<Question> Questions { get; set; }

        [JsonProperty("answers")]
        public List<Answer> Answers { get; set; }
    }
}
