using System;
using System.ServiceProcess;

namespace JarochosDev.Utilities.Net.NetStandard.Common.WindowsServices
{
    public class WindowsServiceRunner : IWindowsServiceRunner
    {
        private static IWindowsServiceRunner _instance;
        public static IWindowsServiceRunner Instance()
        {
            return _instance ?? (_instance = new WindowsServiceRunner());
        }

        public void Run(DebuggableServiceBase[] servicesToRun)
        {
            if (Environment.UserInteractive)
            {
                foreach (var serviceBase in servicesToRun)
                {
                    serviceBase.OnStartDebug();
                }

                Console.WriteLine("Press Alt + F4 to close");

                var keepRunning = true;
                while (keepRunning)
                {
                    var keyInfo = new ConsoleKeyInfo();

                    try
                    {
                        keyInfo = Console.ReadKey();
                    }
                    catch
                    {
                        throw new Exception(
                            "The project cannot read key." + Environment.NewLine +
                            "Try to modify project's properties, " + Environment.NewLine +
                            "set the Output type to Console Application.");
                    }

                    if (keyInfo.Key == ConsoleKey.F4 && keyInfo.Modifiers == ConsoleModifiers.Alt)
                    {
                        keepRunning = false;
                    }
                };

                foreach (var serviceBase in servicesToRun)
                {
                    serviceBase.OnStopDebug();
                }
            }
            else
            {
                ServiceBase.Run(servicesToRun);
            }
        }
    }
}
