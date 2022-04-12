using System.Threading.Tasks;
using System.Text.Json;
using System.Threading;

namespace EventbriteApiV3.Events
{
	public class EventDescriptionRequest : EventbriteRequestBase
	{

		private const string Path = "events/{0}/description/";
		public EventDescriptionRequest(EventbriteContext context, string eventId)
			: base(string.Format(Path, eventId), context)
		{

		}
		public async Task<EventsDescriptionResponse> GetResponseAsync(CancellationToken token)
		{
			using var str = await GetStreamResponseAsync();
			return await JsonSerializer.DeserializeAsync<EventsDescriptionResponse>(str, cancellationToken:token);
			
		}
	}
}
