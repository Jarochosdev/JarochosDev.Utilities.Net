﻿using System.Diagnostics;

namespace JarochosDev.Utilities.Net.NetStandard.Common.Loggers
{
    public class WindowsServiceMessageLogger : IMessageLogger
    {
        public string SourceName { get; }

        public WindowsServiceMessageLogger(string sourceName)
        {
            SourceName = sourceName;
        }
        
        public void Log(string message)
        {
            if (!EventLog.SourceExists(SourceName))
            {
                EventLog.CreateEventSource(SourceName, "Application");
            }

            EventLog.WriteEntry(SourceName, message, EventLogEntryType.Information);
        }
    }
}
