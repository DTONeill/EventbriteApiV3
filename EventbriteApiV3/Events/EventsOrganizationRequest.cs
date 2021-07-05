using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace EventbriteApiV3.Events
{
	public class EventsOrganizationRequest : EventbriteRequestBase
	{
		//<-- bug in event brite. Postman accepts without but our api
		//cannot leave the ending slash out
		private const string Path = "organizations/{0}/events/";
		private readonly static Lazy<JsonSerializer> JsonSerializerLazy = new Lazy<JsonSerializer>(() => JsonSerializer.CreateDefault( new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }));

		public EventsOrganizationRequest(EventbriteContext context, long organizationId, BaseSearchCriterias criterias)
		: base(string.Format(Path, organizationId), context, criterias.ToNameValueCollection())
		{

		}

		public async Task<EventsSearchApiResponse> GetResponseAsync()
		{
			using (var response = await GetStreamResponseAsync())
			using (var tr = new JsonTextReader(response))
			{
				var jsonSerializer = JsonSerializerLazy.Value;
				return jsonSerializer.Deserialize<EventsSearchApiResponse>(tr);
			}
		}
	}
}