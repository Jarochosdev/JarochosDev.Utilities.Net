using System;
using Microsoft.Extensions.DependencyInjection;

namespace JarochosDev.Utilities.Net.NetStandard.Common.DependencyInjection
{
    public class ServiceProviderBuilder : IServiceProviderBuilder
    {
        internal IServiceCollection ServiceCollection { get; }

        public ServiceProviderBuilder():this(new ServiceCollection()) { }
        internal ServiceProviderBuilder(IServiceCollection serviceCollection)
        {
            ServiceCollection = serviceCollection;
        }
        
        public IServiceProviderBuilder AddServiceModule(IServiceModule serviceModule)
        {
            serviceModule.Register(ServiceCollection);
            return this;
        }

        public IServiceProvider Build()
        {
            return ServiceCollection.BuildServiceProvider();
        }
    }
}