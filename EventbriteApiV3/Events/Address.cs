using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace EventbriteApiV3.Events
{
	public class Address
	{
		[JsonPropertyName("address1")]
		public string Line1 { get; set; }

		[JsonPropertyName("address2")]
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
		public double? Latitude { get; set; }

		[JsonPropertyName("longitude")]
		public double? Longitude { get; set; }

		[JsonPropertyName("localized_address_display")]
		public string LocalizedAddressDisplay { get; set; }

		[JsonPropertyName("localized_area_display")]
		public string LocalizedAreaDisplay { get; set; }

		[JsonPropertyName("localized_multi_line_address_display")]
		public IEnumerable<string> LocalizedMultiLineAddressDisplay { get; set; }
	}
}
