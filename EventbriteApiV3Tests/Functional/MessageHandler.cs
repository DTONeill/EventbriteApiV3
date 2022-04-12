using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventbriteApiV3Tests.Functional
{
	internal class MessageHandler : HttpMessageHandler
	{
		private string _source;
		private int _statusCode = 200;
		internal void SetSource(string source)
		{
			_source = source;
		}
		internal void SetStatusCode(int code)
		{
			_statusCode = code;
		}
		protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			var media
				 = _source.StartsWith("<") ? "text/xml" : "application/json";

			return Task.FromResult(new HttpResponseMessage((System.Net.HttpStatusCode)_statusCode)
			{
				Content = new StringContent(_source, Encoding.UTF8, media)
			}); ;
		}
	}
}
