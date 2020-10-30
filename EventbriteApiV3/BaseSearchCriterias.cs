using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace EventbriteApiV3
{
    public class BaseSearchCriterias : ICloneable
    {
        protected Dictionary<string, string> Criterias;
        private const string DateFormat = "yyyy-MM-ddTHH:mm:ss";

        public BaseSearchCriterias() : this(new Dictionary<string, string>())
        {

        }

        private BaseSearchCriterias(Dictionary<string, string> criterias)
        {
            Criterias = criterias;
        }

        public virtual BaseSearchCriterias Page(int page)
        {
            return Add("page", page.ToString());
        }

        public virtual BaseSearchCriterias Add(string key, DateTime value)
        {
            return Add(key, value.ToString(DateFormat));
        }

        public virtual BaseSearchCriterias Add(string key, string value)
        {
            Criterias.Remove(key);
            Criterias.Add(key, value);

            return this;
        }
        /// <summary>
        /// if set to true, will do an extra round trip to get the full event description
        /// </summary>
        internal bool RetrieveFullDescription { get; set; }
        public NameValueCollection ToNameValueCollection()
        {
            var collection = new NameValueCollection();
            foreach (var key in Criterias.Keys)
            {
                collection.Add(key, Criterias[key]);
            }

            return collection;
        }

        public object Clone()
        {
            return new BaseSearchCriterias(Criterias);
        }
    }
}