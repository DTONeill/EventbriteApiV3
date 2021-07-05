using Newtonsoft.Json;

namespace EventbriteApiV3.Events
{
	public class EventsDescriptionResponse
	{
		/// <summary>
		/// description containing html markup
		/// </summary>
		[JsonProperty("description")]
		public string Description { get; set; }
	}
}
