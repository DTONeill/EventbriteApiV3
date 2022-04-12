﻿using System.Text.Json.Serialization;

namespace EventbriteApiV3.Events
{
	public class Original
	{
		[JsonPropertyName("url")]
		public string Url { get; set; }
		[JsonPropertyName("width")]
		public int Width { get; set; }
		[JsonPropertyName("height")]
		public int Height { get; set; }
	}
}
