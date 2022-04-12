using System.Text.Json.Serialization;

namespace EventbriteApiV3.Events
{
	public class EventsDescriptionResponse
	{
		/// <summary>
		/// description containing html markup
		/// </summary>
		[JsonPropertyName("description")]
		public string Description { get; set; }
	}
}
