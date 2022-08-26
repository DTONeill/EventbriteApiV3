using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace EventbriteApiV3
{
    public abstract class EventbriteRequestBase
    {
        protected EventbriteContext Context;

        protected readonly NameValueCollection Query;
        private readonly string _path;
        public Uri Url
        {
            get
            {
                //should be www.eventbrite.com/v3 e.g.
                var hostPath = Context.Uri.Split('/');
                var host = hostPath[0];
                var version = hostPath[1];
                return new UriBuilder(Uri.UriSchemeHttps, host, 443, $"{version}/{_path}")
                {
                    Query = string.Join('&', Query.AllKeys.Select(s => string.Concat(Uri.UnescapeDataString(s), "=", Uri.UnescapeDataString(Query[s]))))
                }.Uri;
            }
        }

        protected EventbriteRequestBase(string path, EventbriteContext context, NameValueCollection query = null)
        {
            Context = context;
            Query = query ?? new NameValueCollection();
            _path = path;
        }
        protected  async Task<Stream> GetStreamResponseAsync(CancellationToken cancellationToken = default)
        {
            using var req = new HttpRequestMessage(HttpMethod.Get, Url);
            req.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Context.AppKey);
            req.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var response = await Context._httpClient.SendAsync(req, cancellationToken);

            return await response.Content.ReadAsStreamAsync();
        }
    }
}
