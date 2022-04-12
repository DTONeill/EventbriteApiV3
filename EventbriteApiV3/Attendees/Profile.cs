using System.Text.Json.Serialization;

namespace EventbriteApiV3.Attendees
{
    public class Profile
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("first_name")]
        public string Firstname { get; set; }

        [JsonPropertyName("last_name")]
        public string Lastname { get; set; }

        [JsonPropertyName("prefix")]
        public string Prefix { get; set; }

        [JsonPropertyName("suffix")]
        public string Suffix { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("job_title")]
        public string JobTitle { get; set; }

        [JsonPropertyName("company")]
        public string Company { get; set; }

        [JsonPropertyName("website")]
        public string Website { get; set; }

        [JsonPropertyName("blog")]
        public string Blog { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("birth_date")]
        public string Birthdate { get; set; }

        [JsonPropertyName("cell_phone")]
        public string Cellphone { get; set; }

        [JsonPropertyName("work_phone")]
        public string Workphone { get; set; }
    }
}