using Newtonsoft.Json;

namespace EventbriteApiV3.Events
{
	public class Original
	{
		[JsonProperty("url")]
		public string Url { get; set; }
		[JsonProperty("width")]
		public int Width { get; set; }
		[JsonProperty("Height")]
		public int Height { get; set; }
	}
}
