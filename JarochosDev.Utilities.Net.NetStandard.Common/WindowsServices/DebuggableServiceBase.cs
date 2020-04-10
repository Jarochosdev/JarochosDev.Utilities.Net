using System;
using System.ServiceProcess;

namespace JarochosDev.Utilities.Net.NetStandard.Common.WindowsServices
{
    public class DebuggableServiceBase : ServiceBase
    {
        public void OnStartDebug()
        {
            this.OnStart(null);
            Console.WriteLine("Started Debugging");
        }

        public void OnStopDebug()
        {
            this.OnStop();
            Console.WriteLine("Stopped Debugging");
        }
    }
}
