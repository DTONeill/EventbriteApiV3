using EventbriteApiV3.Attendees;
using EventbriteApiV3.Events;
using System.Collections.Generic;
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
                foreach (var value in events)
                {
                    value.LongDescription =
                        new Model.TextHtmlString
                        {
                            Html = (await (new EventDescriptionRequest(this, value.Id)).GetResponseAsync()).Description
                        };
                }
            }
        }
        public async Task< EventsSearchApiResponse> GetEventsAsync(BaseSearchCriterias searchCriterias)
        {
            var values = await (new EventSearchEventbriteRequest(this, searchCriterias)).GetResponseAsync();
            if (searchCriterias.RetrieveFullDescription)
			{
                await FillDescriptions(searchCriterias, values.Events);
			}
            return values;
        }
        public async Task<EventsSearchApiResponse> GetEventsByOrganization(long organisationId, BaseSearchCriterias searchCriterias)
		{
            var values = await (new EventsOrganizationRequest(this, organisationId, searchCriterias)).GetResponseAsync();
            if (searchCriterias.RetrieveFullDescription)
            {
                await FillDescriptions(searchCriterias, values.Events);
            }
            return values;

        }
        public AttendeeSearchApiResponse GetAttendees(double eventId, BaseSearchCriterias searchCriterias)
        {
            return new AttendeeSearchEventbriteRequest(this, eventId, searchCriterias).GetResponse();
        }


		public Task< AttendeeSearchApiResponse> GetAttendeesAsync(double eventId, BaseSearchCriterias searchCriterias)
        {
            return (new AttendeeSearchEventbriteRequest(this, eventId, searchCriterias)).GetResponseAsync();
        }
    }
}