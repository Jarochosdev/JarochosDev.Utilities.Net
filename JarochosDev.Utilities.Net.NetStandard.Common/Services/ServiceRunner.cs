using System;
using JarochosDev.Utilities.Net.NetStandard.Common.Processes;

namespace JarochosDev.Utilities.Net.NetStandard.Common.Services
{
    public class ServiceRunner : IServiceRunner
    {
        private static IServiceRunner _instance;

        public static IServiceRunner Instance()
        {
            return _instance ?? (_instance = new ServiceRunner());
        }

        public void Run(IStartableProcess consoleService)
        {
            consoleService.Start();
            consoleService.Stop();
        }

        public void RunEndless(IStartableProcess consoleService)
        {
            consoleService.Start();

            Console.WriteLine("Press Alt + F4 to close");

            var keepRunning = true;
            while (keepRunning)
            {
                var keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.F4 && keyInfo.Modifiers == ConsoleModifiers.Alt)
                {
                    keepRunning = false;
                }
            };

            consoleService.Stop();
        }
    }
}
