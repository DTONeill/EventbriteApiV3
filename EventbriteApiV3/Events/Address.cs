using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace EventbriteApiV3.Events
{
	public class Address
	{
		[JsonPropertyName("address_1")]
		public string Line1 { get; set; }

		[JsonPropertyName("address_2")]
		public string Line2 { get; set; }

		[JsonPropertyName("city")]
		public string City { get; set; }

		[JsonPropertyName("region")]
		public string Region { get; set; }

		[JsonPropertyName("postal_code")]
		public string PostalCode { get; set; }

		/// <summary>
		/// ISO 2 character
		/// </summary>
		[JsonPropertyName("country")]
		public string Country { get; set; }

		[JsonPropertyName("latitude")]
		public string Latitude { get; set; }
		/// <summary>
		/// "-122.5078119"
		/// </summary>
		[JsonPropertyName("longitude")]
		public string Longitude { get; set; }

		[JsonPropertyName("localized_address_display")]
		public string LocalizedAddressDisplay { get; set; }

		[JsonPropertyName("localized_area_display")]
		public string LocalizedAreaDisplay { get; set; }

		[JsonPropertyName("localized_multi_line_address_display")]
		public IEnumerable<string> LocalizedMultiLineAddressDisplay { get; set; }
	}
}
