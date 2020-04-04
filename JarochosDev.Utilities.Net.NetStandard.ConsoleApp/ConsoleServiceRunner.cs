using System;

namespace JarochosDev.Utilities.Net.NetStandard.ConsoleApp
{
    public class ConsoleServiceRunner : IConsoleServiceRunner
    {
        private static IConsoleServiceRunner _instance;

        public static IConsoleServiceRunner Instance()
        {
            return _instance ?? (_instance = new ConsoleServiceRunner());
        }

        public void Run(IConsoleService consoleService)
        {
            consoleService.Start();
            consoleService.Stop();
        }

        public void RunEndless(IConsoleService consoleService)
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
