using System;

namespace JarochosDev.Utilities.Net.NetStandard.Common.Proxy
{
    public class ProxyEnvironment : IProxyEnvironment
    {
        private static IProxyEnvironment _instance;
        public static IProxyEnvironment Instance()
        {
            return _instance ?? (_instance = new ProxyEnvironment());
        }

        public string UserName => Environment.UserName;
        public string MachineName => Environment.MachineName;
    }
}