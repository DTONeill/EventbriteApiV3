# EventbriteApiV3

Wrapper in top of Eventbrite api v3.  It allow you to fetch attendees and events easily using your application key.
https://www.eventbrite.com/platform/api#/introduction/about-our-api

## Getting started

First you should create your own API key at https://www.eventbrite.ca/platform

### Fetching Events
```
var eventbriteContext = new EventbriteContext("Your API key");

var criterias = new EventSearchCriterias()
                .OnlyFree()
                .OrganizerId(18945678)
                .StartAfter(DateTime.Now)
                .OrderBy(EventSearchCriterias.SortOrder.Date);

var eventsFirstPage = Context.GetEvents(criterias);

if(eventsFirstPage.Pagination.PageCount > 2) {
	criterias.Page(2);

	var eventsSecondPage = Context.GetEvents(criterias);
}
```

### Fetching Attendees

```
var eventbriteContext = new EventbriteContext("Your API key");

var criterias = new AttendeeSearchCriterias()
                .Status(AttendeeSearchCriterias.AttendeeStatus.Attending);

var result = Context.GetAttendees({event id});
```