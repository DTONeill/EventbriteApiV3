using EventbriteApiV3.Attendees;
using EventbriteApiV3.Events;
using EventbriteApiV3.Helpers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace EventbriteApiV3
{
    public class EventbriteContext
    {
        public readonly string AppKey;
        public readonly string Uri;
        private const string ProdUri = "www.eventbriteapi.com/v3";
        public readonly HttpMessageInvoker _httpClient;
        public EventbriteContext(HttpClient httpClient, string appKey, string uri = ProdUri)
        {
            AppKey = appKey;
            Uri = uri;
            _httpClient = httpClient;
        }

        public async Task< EventsSearchApiResponse> GetEvents(BaseSearchCriterias searchCriterias)
        {
            return await (new EventSearchEventbriteRequest(this, searchCriterias)).GetResponseAsync();
        }
        private async Task FillDescriptions(BaseSearchCriterias searchCriterias, ICollection<Event> events, CancellationToken token = default)
        {
            if (searchCriterias.RetrieveFullDescription)
            {
                try
                {
                    //note: we cannot request a lot of
                    // parrallel requests on most api's
                    // that is considered 'rude' and often is throttled down.
                    var tasks = events.Select(x => new { x, DescriptionTask = ( new EventDescriptionRequest(this, x.Id).GetResponseAsync(token)) });
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

        public Task<AttendeeSearchApiResponse> GetAttendeesAsync(double eventId, BaseSearchCriterias searchCriterias)
        {
            return (new AttendeeSearchEventbriteRequest(this, eventId, searchCriterias)).GetResponseAsync();
        }
    }
}
