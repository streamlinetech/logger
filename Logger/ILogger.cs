using System;
using System.Threading.Tasks;
using Streamline.Logging.Models;

namespace Streamline.Logging
{
    public interface ILogger
    {
        void Log(string message);
        void Log(string message, EntryType entryType);
        void Log(string message, string applicationName, string userName, EntryType entryType);
        void Log(string message, string applicationName, string userName, string ipAddress, EntryType entryType);
        void Log(Log log);
        void LogWithFormat(string message, params object[] args);
        void LogException(Exception ex);

        Task LogAsync(string message);
        Task LogAsync(string message, EntryType entryType);
        Task LogAsync(string message, string applicationName, string userName, EntryType entryType);
        Task LogAsync(string message, string applicationName, string userName, string ipAddress, EntryType entryType);
        Task LogAsync(Log log);
        Task LogWithFormatAsync(string message, params object[] args);
        Task LogExceptionAsync(Exception ex);
    }
}