using System;

namespace JarochosDev.Utilities.Net.NetStandard.Common.Proxies
{
    public class ProxyDateTime : IProxyDateTime
    {
        private static IProxyDateTime _instance;
        public static IProxyDateTime Instance()
        {
            return _instance ?? (_instance = new ProxyDateTime());
        }

        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}