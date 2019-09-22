using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;

namespace EventbriteApiV3.Attendees
{
    public class AttendeeSearchCriterias : BaseSearchCriterias
    {
        private const string EventIdKey = "event_id";
        private const string AttendeesKey = "attendee_ids";
        private const string StatusKey = "status";

        public enum AttendeeStatus
        {
            Attending, NotAttending, Unpaid
        }

        public AttendeeSearchCriterias Event(double id)
        {
            return Add(EventIdKey, id.ToString(CultureInfo.InvariantCulture));
        }

        public AttendeeSearchCriterias Status(AttendeeStatus status)
        {
            string statusValue = "";
            switch (status)
            {
                case AttendeeStatus.Attending:
                    statusValue = "attending";
                    break;
                case AttendeeStatus.NotAttending:
                    statusValue = "not_attending";
                    break;
                case AttendeeStatus.Unpaid:
                    statusValue = "unpaid";
                    break;
            }

            return Add(StatusKey, statusValue);
        }

        public AttendeeSearchCriterias Attendees(List<double> ids)
        {
            return Add(AttendeesKey, JsonConvert.SerializeObject(ids));
        }

        public new AttendeeSearchCriterias Add(string key, string value)
        {
            base.Add(key, value);

            return this;
        }

        public new AttendeeSearchCriterias Add(string key, DateTime value)
        {
            base.Add(key, value);

            return this;
        }

        public new AttendeeSearchCriterias Page(int page)
        {
            base.Page(page);

            return this;
        }
    }
}