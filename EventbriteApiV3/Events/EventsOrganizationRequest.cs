using Newtonsoft.Json;
using System.Threading.Tasks;

namespace EventbriteApiV3.Events
{
	public class EventsOrganizationRequest: EventbriteRequestBase
	{
		private const string Path = "organizations/{0}/events/";
		public EventsOrganizationRequest(EventbriteContext context, long organizationId, BaseSearchCriterias criterias)
		: base(string.Format(Path, organizationId), context, criterias.ToNameValueCollection())
		{

		}

		public async Task<EventsSearchApiResponse> GetResponseAsync()
		{
			var response = await GetStreamResponseAsync();
			var JsonSerializer = new JsonSerializer();
			var result = JsonSerializer.Deserialize< EventsSearchApiResponse>(new JsonTextReader( response ));
			return result;
		}
	}
}
