using System;
using System.Runtime.CompilerServices;

namespace ManubiaTask
{
    public enum LogLevel
    {
        APP_STATE_INFO = 0,
        INFO = 1,
        WARNING = 2,
        ERROR = 3,
    }

    public static class Logger
    {
        /// <summary>
        /// Console.WriteLine method is thread-save
        /// </summary>
        public static void Log(LogLevel level, string callerObjectName, string message, Exception e = null, [CallerMemberName] string memberName = "")
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"[{DateTime.Now:H:mm:ss}][{callerObjectName}][{memberName}] ");
            var consoleMessage = string.Empty;
            switch(level)
            {
                case LogLevel.APP_STATE_INFO:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    consoleMessage = message;
                    break;
                case LogLevel.INFO:
                    Console.ForegroundColor = ConsoleColor.Green;
                    consoleMessage = message;
                    break;
                case LogLevel.WARNING:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    consoleMessage = message;
                    break;
                case LogLevel.ERROR:
                    Console.ForegroundColor = ConsoleColor.Red;
                    consoleMessage = $"{message}{(e == null ? string.Empty : $" Exception: {e.Message}")}";
                    break;
            }

            Console.WriteLine(consoleMessage);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
