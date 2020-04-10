using JarochosDev.Utilities.Net.NetStandard.Common.Processes;

namespace JarochosDev.Utilities.Net.NetStandard.Common.Services
{
    public interface IServiceRunner
    {
        void Run(IStartableProcess consoleService);
        void RunEndless(IStartableProcess consoleService);
    }
}