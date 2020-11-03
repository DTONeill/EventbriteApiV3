using Newtonsoft.Json;
using System.Threading.Tasks;

namespace EventbriteApiV3.Events
{
    public class EventSearchEventbriteRequest : EventbriteRequestBase
    {
        private const string Path = "events/search/";

        public EventSearchEventbriteRequest(EventbriteContext context, BaseSearchCriterias criterias)
            : base(Path, context, criterias.ToNameValueCollection())
        {

        }

        public EventsSearchApiResponse GetResponse()
        {
            var response = GetJsonResponse();

            return JsonConvert.DeserializeObject<EventsSearchApiResponse>(response);
        }

        public async Task<EventsSearchApiResponse> GetResponseAsync()
        {
            var response = await GetJsonResponseAsync();

            return JsonConvert.DeserializeObject<EventsSearchApiResponse>(response);
        }
    }
}