namespace JarochosDev.Utilities.Net.NetStandard.ConsoleApp
{
    public interface IConsoleServiceRunner
    {
        void Run(IConsoleService consoleService);
        void RunEndless(IConsoleService consoleService);
    }
}