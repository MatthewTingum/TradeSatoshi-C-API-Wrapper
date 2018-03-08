using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TradeSatoshiAPI.CloudFlare
{
    internal static class HttpMessageHandlerExtensions
    {
        public static HttpMessageHandler GetMostInnerHandler(this HttpMessageHandler self)
        {
            var delegatingHandler = self as DelegatingHandler;
            return delegatingHandler == null ? self : delegatingHandler.InnerHandler.GetMostInnerHandler();
        }
    }
}
