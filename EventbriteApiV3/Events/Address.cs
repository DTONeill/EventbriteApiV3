using Newtonsoft.Json;
using System.Collections.Generic;

namespace EventbriteApiV3.Events
{
	public class Address
	{
		[JsonProperty("address1")]
		public string Line1 { get; set; }

		[JsonProperty("address2")]
		public string Line2 { get; set; }

		[JsonProperty("city")]
		public string City { get; set; }

		[JsonProperty("region")]
		public string Region { get; set; }

		[JsonProperty("postal_code")]
		public string PostalCode { get; set; }

		/// <summary>
		/// ISO 2 character
		/// </summary>
		[JsonProperty("country")]
		public string Country { get; set; }

		[JsonProperty("latitude")]
		public double? Latitude { get; set; }

		[JsonProperty("longitude")]
		public double? Longitude { get; set; }

		[JsonProperty("localized_address_display")]
		public string LocalizedAddressDisplay { get; set; }

		[JsonProperty("localized_area_display")]
		public string LocalizedAreaDisplay { get; set; }

		[JsonProperty("localized_multi_line_address_display")]
		public IEnumerable<string> LocalizedMultiLineAddressDisplay { get; set; }
	}
}
