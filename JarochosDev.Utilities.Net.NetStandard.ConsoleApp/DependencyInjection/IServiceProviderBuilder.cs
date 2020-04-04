using System;

namespace JarochosDev.Utilities.Net.NetStandard.ConsoleApp.DependencyInjection
{
    public interface IServiceProviderBuilder
    {
        void AddServiceModule(IServiceModule serviceModule);
        IServiceProvider Build();
    }
}