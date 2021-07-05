using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EventbriteApiV3.Events
{
	public class EventDescriptionRequest : EventbriteRequestBase
	{

		private const string Path = "events/{0}/description/";
		public EventDescriptionRequest(EventbriteContext context, long eventId)
			: base(string.Format(Path, eventId), context)
		{

		}
		public async Task<EventsDescriptionResponse> GetResponseAsync()
		{
			using (var response = await GetStreamResponseAsync())
			{
				var JsonSerializer = new JsonSerializer();
				return JsonSerializer.Deserialize<EventsDescriptionResponse>(new JsonTextReader(response));
			}
		}
	}
}
