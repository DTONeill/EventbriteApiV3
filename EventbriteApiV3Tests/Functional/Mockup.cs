using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace EventbriteApiV3Tests.Functional
{
	class Mockup
	{
		internal static HttpClient GetMyHandler(string source)
		{
			var handler = new MessageHandler();
			handler.SetSource(source);
			return new HttpClient(handler);
		}
		internal static HttpClient GetMyHandler(string source, int errorCode)
		{
			var handler = new MessageHandler();
			handler.SetSource(source);
			handler.SetStatusCode(errorCode);
			return new HttpClient(handler);
		}
	}
}
