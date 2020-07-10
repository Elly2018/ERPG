using System;
using System.Collections.Generic;

namespace ERPGServer
{
    public class ServerLog
    {
        private static List<ILogger> loggers = new List<ILogger>();

        public static void AddLogger(ILogger logger)
        {
            loggers.Add(logger);
        }

        public static void Log(string tag, string message)
        {
            foreach (var i in loggers)
                i.Log(tag, message);
        }

        public static void LogWarning(string tag, string message)
        {
            foreach (var i in loggers)
                i.LogWarning(tag, message);
        }

        public static void LogError(string tag, string message)
        {
            foreach (var i in loggers)
                i.LogError(tag, message);
        }

        public static void LogException(string tag, string message)
        {
            foreach (var i in loggers)
                i.LogException(tag, message);
        }
    }
}
