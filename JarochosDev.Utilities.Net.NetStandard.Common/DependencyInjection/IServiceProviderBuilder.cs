using System;

namespace JarochosDev.Utilities.Net.NetStandard.Common.DependencyInjection
{
    public interface IServiceProviderBuilder
    {
        IServiceProviderBuilder AddServiceModule(IServiceModule serviceModule);
        IServiceProvider Build();
    }
}