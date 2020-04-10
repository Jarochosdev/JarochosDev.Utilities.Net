using Microsoft.Extensions.DependencyInjection;

namespace JarochosDev.Utilities.Net.NetStandard.Common.DependencyInjection
{
    public interface IServiceModule
    {
        void Register(IServiceCollection serviceCollection);
    }
}
