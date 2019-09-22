using Newtonsoft.Json;

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
    }
}