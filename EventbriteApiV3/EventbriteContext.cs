using EventbriteApiV3.Attendees;
using EventbriteApiV3.Events;
using System;
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

        public Task<EventsSearchApiResponse> GetEventsAsync(BaseSearchCriterias searchCriterias)
        {
            return (new EventSearchEventbriteRequest(this, searchCriterias)).GetResponseAsync();
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
