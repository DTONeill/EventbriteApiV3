using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace EventbriteApiV3.Events
{
	public class VenueRequest: EventbriteRequestBase
	{
		private const string Path = "venues/{0}/";
		private readonly static Lazy<JsonSerializer> JsonSerializerLazy = new Lazy<JsonSerializer>(() => JsonSerializer.CreateDefault(new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }));
		public VenueRequest(EventbriteContext context, long venueId)
			: base(string.Format(Path, venueId), context)
		{

		}
		public async Task<Venue> GetResponseAsync()
		{
			using (var response = await GetStreamResponseAsync())
			using (var tr = new JsonTextReader(response))
			{
				return JsonSerializerLazy.Value.Deserialize<Venue>(tr);
			}
		}
	}
}
