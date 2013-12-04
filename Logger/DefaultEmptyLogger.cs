using System;
using System.Threading.Tasks;
using Streamline.Logging.Helpers;
using Streamline.Logging.Models;

namespace Streamline.Logging
{
    public class DefaultEmptyLogger : ILogger
    {
        public void Log(string message)
        {

        }

        public void Log(string message, EntryType entryType)
        {

        }

        public void Log(string message, string applicationName, string userName, EntryType entryType)
        {

        }

        public void Log(string message, string applicationName, string userName, string ipAddress, EntryType entryType)
        {

        }

        public void Log(Log log)
        {

        }

        public void LogWithFormat(string message, params object[] args)
        {

        }

        public void LogException(Exception ex)
        {

        }

        public async Task LogAsync(string message)
        {
            await TaskHelpers.Empty;
        }

        public async Task LogAsync(string message, EntryType entryType)
        {
            await TaskHelpers.Empty;
        }

        public async Task LogAsync(string message, string applicationName, string userName, EntryType entryType)
        {
            await TaskHelpers.Empty;
        }

        public async Task LogAsync(string message, string applicationName, string userName, string ipAddress, EntryType entryType)
        {
            await TaskHelpers.Empty;
        }

        public async Task LogAsync(Log log)
        {
            await TaskHelpers.Empty;
        }

        public async Task LogWithFormatAsync(string message, params object[] args)
        {
            await TaskHelpers.Empty;
        }

        public async Task LogExceptionAsync(Exception ex)
        {
            await TaskHelpers.Empty;
        }


    }
}