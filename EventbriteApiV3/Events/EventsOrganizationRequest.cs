using System.Text.Json;
using System;
using System.Threading.Tasks;

namespace EventbriteApiV3.Events
{
	public class EventsOrganizationRequest : EventbriteRequestBase
	{
		private const string Path = "organizations/{0}/events/";
		
		public EventsOrganizationRequest(EventbriteContext context, long organizationId, BaseSearchCriterias criterias)
		: base(string.Format(Path, organizationId), context, criterias.ToNameValueCollection())
		{

		}

		public async Task<EventsSearchApiResponse> GetResponseAsync()
		{
			using var str = await GetStreamResponseAsync();
			return await JsonSerializer.DeserializeAsync<EventsSearchApiResponse>(str);			
		}
	}
}