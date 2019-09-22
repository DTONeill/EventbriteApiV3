using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace EventbriteApiV3.Attendees
{
    public class Answer
    {
        [JsonProperty("question_id")]
        public double QuestionId { get; set; }

        [JsonProperty("question")]
        public string Question { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("answer")]
        public string AnswerText { get; set; }
    }
}
