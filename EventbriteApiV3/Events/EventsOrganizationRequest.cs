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
			using (var response = await GetStreamResponseAsync())
			{
				var jsonSerializer = JsonSerializer.CreateDefault(new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore})

				var result = jsonSerializer.Deserialize<EventsSearchApiResponse>(new JsonTextReader(response));
				return result;
			}
		}
	}
}
