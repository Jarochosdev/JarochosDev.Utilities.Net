namespace JarochosDev.Utilities.Net.NetStandard.Common.WindowsServices
{
    public interface IWindowsServiceRunner
    {
        void Run(DebuggableServiceBase[] servicesToRun);
    }
}