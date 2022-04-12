using System.Text.Json.Serialization;

namespace EventbriteApiV3.Attendees
{
	public class Answer
    {
        [JsonPropertyName("question_id")]
        public double QuestionId { get; set; }

        [JsonPropertyName("question")]
        public string Question { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("answer")]
        public string AnswerText { get; set; }
    }
}
