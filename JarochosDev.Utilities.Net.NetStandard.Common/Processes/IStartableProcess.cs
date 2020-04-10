namespace JarochosDev.Utilities.Net.NetStandard.Common.Processes
{
    public interface IStartableProcess : IStarterProcess, IFinalizerProcess
    {
    }

    public interface IFinalizerProcess
    {
        void Stop();
    }

    public interface IStarterProcess
    {
        IFinalizerProcess Start();
    }
}
