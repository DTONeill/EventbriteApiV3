using EventbriteApiV3.Attendees;
using EventbriteApiV3.Events;
using EventbriteApiV3.Helpers;
using System;
using System.Collections.Concurrent;
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
                    await tasks.ForEachAsync(3, async (x) => x.x.LongDescription = new Model.TextHtmlString { Html = (await x.DescriptionTask).Description });
                }
                catch (Exception ex)
                {
                    Trace.TraceError("FillDescriptions failed with {0}", ex);
                }
            }
        }

        private async Task FillVenues(BaseSearchCriterias searchCriterias, IList<Event> events)
        {
            if (searchCriterias.RetrieveVenueInformation)
            {
                var venueIds = events
                    .Where(w => w.VenueId != null)
                    .Select(s => s.VenueId.Value).Distinct().ToArray();

                try
                {
                    var tasks = venueIds.Select(x => new { key = x, VenueTask = new VenueRequest(this, x).GetResponseAsync() });
                    var concurrentDict = new ConcurrentDictionary<long, Venue>();
                    await tasks.ForEachAsync(3, async (x) =>
                    {
                        try
                        {
                            var venue = await x.VenueTask;
                            concurrentDict.TryAdd(x.key, venue);
                        }
                        catch(Exception ex)
						{
                            Trace.TraceError($"Cannot associate venueid {x.key} with retrieved object {ex.Message}");
						}
                    });
                    foreach (var @event in events)
                    {
                        if (@event.VenueId != null)
                        {
                            concurrentDict.TryGetValue(@event.VenueId.Value, out Venue venue);
                            @event.Venue = venue;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Trace.TraceError("FillVenues failed with {0}", ex);
                }
            }
        }

        public async Task<EventsSearchApiResponse> GetEventsAsync(BaseSearchCriterias searchCriterias)
        {
            var values = await (new EventSearchEventbriteRequest(this, searchCriterias)).GetResponseAsync();
            await FillDescriptions(searchCriterias, values.Events);
            await FillVenues(searchCriterias, values.Events);
            return values;
        }

        public async Task<EventsSearchApiResponse> GetEventsByOrganization(long organisationId, BaseSearchCriterias searchCriterias)
        {
            var values = await (new EventsOrganizationRequest(this, organisationId, searchCriterias)).GetResponseAsync();
            await FillDescriptions(searchCriterias, values.Events);
            await FillVenues(searchCriterias, values.Events);
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
