using System.Text.Json;
using System.Threading;
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

     
        public async Task<EventsSearchApiResponse> GetResponseAsync(CancellationToken token = default)
        {
            using var str = await GetStreamResponseAsync(token);
            return await JsonSerializer.DeserializeAsync<EventsSearchApiResponse>(str, cancellationToken: token);
        }
    }
}