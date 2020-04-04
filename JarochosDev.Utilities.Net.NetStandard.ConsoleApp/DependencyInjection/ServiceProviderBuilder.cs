using System;
using Microsoft.Extensions.DependencyInjection;

namespace JarochosDev.Utilities.Net.NetStandard.ConsoleApp.DependencyInjection
{
    public class ServiceProviderBuilder : IServiceProviderBuilder
    {
        internal IServiceCollection ServiceCollection { get; }

        internal ServiceProviderBuilder(IServiceCollection serviceCollection)
        {
            ServiceCollection = serviceCollection;
        }
        
        public void AddServiceModule(IServiceModule serviceModule)
        {
            serviceModule.Register(ServiceCollection);
        }

        public IServiceProvider Build()
        {
            return ServiceCollection.BuildServiceProvider();
        }
    }
}