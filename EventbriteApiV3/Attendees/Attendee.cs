using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EventbriteApiV3.Attendees
{
    public class Attendee
    {
        [JsonPropertyName("id")]
        public double Id { get; set; }

        [JsonPropertyName("ticket_class_id")]
        public string TicketClassId { get; set; }

        [JsonPropertyName("ticket_class_name")]
        public string TicketClassName { get; set; }

        [JsonPropertyName("profile")]
        public Profile Profile { get; set; }

        [JsonPropertyName("questions")]
        public ICollection<Question> Questions { get; set; }

        [JsonPropertyName("answers")]
        public ICollection<Answer> Answers { get; set; }
    }
}
