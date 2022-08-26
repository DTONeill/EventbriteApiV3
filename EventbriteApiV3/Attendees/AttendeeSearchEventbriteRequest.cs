using System.Text.Json;
using System.Threading.Tasks;

namespace EventbriteApiV3.Attendees
{
    public class AttendeeSearchEventbriteRequest : EventbriteRequestBase
    {
        private const string Path = "events/{0}/attendees/";

        public AttendeeSearchEventbriteRequest(EventbriteContext context, double eventId, BaseSearchCriterias criterias)
            : base(string.Format(Path, eventId), context, criterias.ToNameValueCollection())
        {

        }
     
        public async Task<AttendeeSearchApiResponse> GetResponseAsync()
        {
            using var str = await GetStreamResponseAsync();
            return await JsonSerializer.DeserializeAsync<AttendeeSearchApiResponse>(str);
        }
    }
}