using Newtonsoft.Json;

namespace EventbriteApiV3.Events
{
	public class Logo
	{
		[JsonProperty("id")]
		public long Id { get; set; }
		[JsonProperty("aspect_ratio")]
		public double AspectRatio { get; set; }
		[JsonProperty("edge_color")]
		public string EdgeColor { get; set; }
		[JsonProperty("edge_color_set")]
		public bool EdgeColorSet { get; set; }
		/// <summary>
		/// mostly the cropped logo
		/// </summary>
		[JsonProperty("url")]
		public string Url { get; set; }
		[JsonProperty("original")]
		public Original Original { get; set; }
	}
}
