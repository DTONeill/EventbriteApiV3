using EventbriteApiV3.Attendees;
using EventbriteApiV3.Events;
using EventbriteApiV3.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
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
                try
                {
                    //note: we cannot request a lot of
                    // parrallel requests on most api's
                    // that is considered 'rude' and often is throttled down.
                    var tasks = events.Select(x => new { x, DescriptionTask = new EventDescriptionRequest(this, x.Id).GetResponseAsync() });
                    await tasks.ForEachAsync(4, async (x) => x.x.LongDescription = new Model.TextHtmlString { Html = (await x.DescriptionTask).Description });
                }
                catch (Exception ex)
                {
                    Trace.TraceError("FillDescriptions failed with {0}", ex);
                }
            }
        }

        public async Task<EventsSearchApiResponse> GetEventsAsync(BaseSearchCriterias searchCriterias)
        {
            var values = await (new EventSearchEventbriteRequest(this, searchCriterias)).GetResponseAsync();
            await FillDescriptions(searchCriterias, values.Events);
            return values;
        }

        public async Task<EventsSearchApiResponse> GetEventsByOrganization(long organisationId, BaseSearchCriterias searchCriterias)
        {
            var values = await (new EventsOrganizationRequest(this, organisationId, searchCriterias)).GetResponseAsync();
            await FillDescriptions(searchCriterias, values.Events);
            return values;
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
