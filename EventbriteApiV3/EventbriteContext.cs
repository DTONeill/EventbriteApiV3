using EventbriteApiV3.Attendees;
using EventbriteApiV3.Events;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventbriteApiV3
{
    public class EventbriteContext
    {
        public readonly string AppKey;
        public readonly string Uri;
        private const string ProdUri = "www.eventbriteapi.com/v3";

        public EventbriteContext(string appKey, string uri = ProdUri)
        {
            AppKey = appKey;
            Uri = uri;
        }

        public EventsSearchApiResponse GetEvents(BaseSearchCriterias searchCriterias)
        {
            return new EventSearchEventbriteRequest(this, searchCriterias).GetResponse();
        }
        private async Task FillDescriptions(BaseSearchCriterias searchCriterias, IList<Event> events)
        {
            if (searchCriterias.RetrieveFullDescription)
            {
                var tasks = events.Select(x => new EventDescriptionRequest(this, x.Id).GetResponseAsync()).ToArray();
                await Task.WhenAll(tasks);
                var descriptions = tasks.Select(async x => (await x).Description).ToArray();
                for (var i = 0; i <= events.Count; i++)
                {
                    events[i].LongDescription = new Model.TextHtmlString { Html = await descriptions[i] };
                }
            }
        }

        public async Task<EventsSearchApiResponse> GetEventsAsync(BaseSearchCriterias searchCriterias)
        {
            var values = await (new EventSearchEventbriteRequest(this, searchCriterias)).GetResponseAsync();
            await FillDescriptions(searchCriterias, values.Events);
            return values;
        }

        public Task<EventsSearchApiResponse> GetEventsByOrganization(long organisationId, BaseSearchCriterias searchCriterias)
        {
            return (new EventsOrganizationRequest(this, organisationId, searchCriterias)).GetResponseAsync();
        }

        public AttendeeSearchApiResponse GetAttendees(double eventId, BaseSearchCriterias searchCriterias)
        {
            return new AttendeeSearchEventbriteRequest(this, eventId, searchCriterias).GetResponse();
        }

        public Task<AttendeeSearchApiResponse> GetAttendeesAsync(double eventId, BaseSearchCriterias searchCriterias)
        {
            return (new AttendeeSearchEventbriteRequest(this, eventId, searchCriterias)).GetResponseAsync();
        }
    }
}
