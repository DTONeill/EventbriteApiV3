using System.Text.Json;
using System;
using System.Threading.Tasks;

namespace EventbriteApiV3.Events
{
	public class VenueRequest: EventbriteRequestBase
	{
		private const string Path = "venues/{0}/";
		public VenueRequest(EventbriteContext context, string venueId)
			: base(string.Format(Path, venueId), context)
		{

		}
		public async Task<Venue> GetResponseAsync()
		{
			using var str = await GetStreamResponseAsync();
			return await JsonSerializer.DeserializeAsync<Venue>(str);
			
		}
	}
}
