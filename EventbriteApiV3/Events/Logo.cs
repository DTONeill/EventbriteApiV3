using System.Text.Json.Serialization;

namespace EventbriteApiV3.Events
{
	public class Logo
	{
		[JsonPropertyName("id")]
		public string Id { get; set; }
		[JsonPropertyName("aspect_ratio")]
		public string AspectRatio { get; set; }
		[JsonPropertyName("edge_color")]
		public string EdgeColor { get; set; }
		[JsonPropertyName("edge_color_set")]
		public bool EdgeColorSet { get; set; }
		/// <summary>
		/// mostly the cropped logo
		/// </summary>
		[JsonPropertyName("url")]
		public string Url { get; set; }
		[JsonPropertyName("original")]
		public Original Original { get; set; }
	}
}
