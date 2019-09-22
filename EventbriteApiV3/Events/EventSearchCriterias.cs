using System;
using System.Globalization;

namespace EventbriteApiV3.Events
{
    public class EventSearchCriterias : BaseSearchCriterias
    {
        private const string IsFreeKey = "price";
        private const string StartBeforeKey = "start_date.range_end";
        private const string StartAfterKey = "start_date.range_start";
        private const string OrganizerIdKey = "organizer.id";
        private const string SortByKey = "sort_by";

        public enum SortOrder
        {
            Date,
            DateInverse,
            Best,
            BestInverse,
            Distance,
            DistanceInverse
        };

        public EventSearchCriterias OnlyFree()
        {
            return Add(IsFreeKey, "free");
        }

        public EventSearchCriterias OnlyPaid()
        {
            return Add(IsFreeKey, "paid");
        }

        public EventSearchCriterias StartBefore(DateTime date)
        {
            return Add(StartBeforeKey, date);
        }

        public EventSearchCriterias StartAfter(DateTime date)
        {
            return Add(StartAfterKey, date);
        }

        public EventSearchCriterias OrganizerId(double id)
        {
            return Add(OrganizerIdKey, id.ToString(CultureInfo.InvariantCulture));
        }

        public EventSearchCriterias OrderBy(SortOrder sort)
        {
            string sortOrder = "";
            switch (sort)
            {
                case SortOrder.Best:
                    sortOrder = "best";
                    break;
                case SortOrder.BestInverse:
                    sortOrder = "-best";
                    break;
                case SortOrder.Date:
                    sortOrder = "date";
                    break;
                case SortOrder.DateInverse:
                    sortOrder = "-date";
                    break;
                case SortOrder.Distance:
                    sortOrder = "distance";
                    break;
                case SortOrder.DistanceInverse:
                    sortOrder = "-distance";
                    break;
            }

            return Add(SortByKey, sortOrder);
        }

        public new EventSearchCriterias Add(string key, string value)
        {
            base.Add(key, value);

            return this;
        }

        public new EventSearchCriterias Add(string key, DateTime value)
        {
            base.Add(key, value);

            return this;
        }

        public new EventSearchCriterias Page(int page)
        {
            base.Page(page);

            return this;
        }
    }
}