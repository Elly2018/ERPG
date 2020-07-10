using System;

namespace ERPGServer
{
    class ConsoleLog : ILogger
    {
        public void Log(string tag, string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[{tag}] {message}");
        }

        public void LogError(string tag, string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[{tag}] {message}");
        }

        public void LogException(string tag, string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"[{tag}] {message}");
        }

        public void LogWarning(string tag, string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[{tag}] {message}");
        }
    }
}
