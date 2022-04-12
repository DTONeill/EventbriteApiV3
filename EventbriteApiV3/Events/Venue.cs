using System.Text.Json.Serialization;

namespace EventbriteApiV3.Events
{
    /// <summary>
    /// descripes a venue/location for an event
    /// </summary>
    public class Venue
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("address")]
        public Address Address { get; set; }

        [JsonPropertyName("age_restriction")]
        public string AgeRestriction { get; set; }

        [JsonPropertyName("capacity")]
        public int? Capacity { get; set; }

        [JsonPropertyName("capacity_is_custom")]
        public bool CapcityIsCustom { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("latitude")]
        public double? Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double? Longitude { get; set; }

        [JsonPropertyName("resource_uri")]
        internal string ResourceUri { get; set; }
    }
}
