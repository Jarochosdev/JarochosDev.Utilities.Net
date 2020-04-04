using Microsoft.Extensions.DependencyInjection;

namespace JarochosDev.Utilities.Net.NetStandard.ConsoleApp.DependencyInjection
{
    public interface IServiceModule
    {
        void Register(IServiceCollection serviceCollection);
    }
}
