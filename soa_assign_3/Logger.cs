/// Logger.cs
/// Thomas Kempton & Samuel Lewis 2012
///

namespace soa_assign_3
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.IO;

    public static class Logger
    {
        public enum LogType
        {
            Message,
            Warning,
            Error
        }

        /// <summary>
        /// Writes a log entry.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="type">The type.</param>
        /// <param name="module">The module.</param>
        /// <param name="message">The message.</param>
        public static void Log(string filePath, LogType type, string module, string message)
        {
            using (var stream = new FileStream(filePath, FileMode.OpenOrCreate | FileMode.Append, FileAccess.Write))
            using (var writer = new StreamWriter(stream))
            {
                writer.WriteLine(
                    "{0:HH:mm:ss MM-dd-yyyy} - {1} in {2}: {3}",
                    DateTime.Now,
                    ConvertType(type),
                    module,
                    message);
            }
        }

        /// <summary>
        /// Logs a message.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="module">The module.</param>
        /// <param name="message">The message.</param>
        public static void LogMessage(string filePath, string module, string message)
        {
            Log(filePath, LogType.Message, module, message);
        }

        /// <summary>
        /// Logs a warning.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="module">The module.</param>
        /// <param name="message">The message.</param>
        public static void LogWarning(string filePath, string module, string message)
        {
            Log(filePath, LogType.Warning, module, message);
        }

        /// <summary>
        /// Logs an error.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="module">The module.</param>
        /// <param name="message">The message.</param>
        public static void LogError(string filePath, string module, string message)
        {
            Log(filePath, LogType.Error, module, message);
        }

        private static string ConvertType(LogType type)
        {
            switch(type)
            {
                case LogType.Message:
                    return "Message";
                case LogType.Warning:
                    return "Warning";
                case LogType.Error:
                    return "Error";
                default:
                    throw new InvalidOperationException("I don't even know how this happened!?");
            }
        }
    }
}