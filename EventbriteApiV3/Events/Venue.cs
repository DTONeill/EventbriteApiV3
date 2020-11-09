using Newtonsoft.Json;

namespace EventbriteApiV3.Events
{
	/// <summary>
	/// descripes a venue/location for an event
	/// </summary>
    public class Venue
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("address")]
		public Address Address { get; set; }

		[JsonProperty("age_restriction")]
		public string AgeRestriction { get; set; }

		[JsonProperty("capacity")]
		public int? Capacity { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("latitude")]
		public double? Latitude { get; set; }

		[JsonProperty("longitude")]
		public double? Longitude { get; set; }

		[JsonProperty("resource_uri")]
		internal string ResourceUri { get; set; }
	}
}
