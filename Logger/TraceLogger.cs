using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Streamline.Logging.Extensions;
using Streamline.Logging.Models;

namespace Streamline.Logging
{
    public class TraceLogger : ILogger
    {
        public void Log(string message)
        {
            Log(message, EntryType.Information);
        }

        public void Log(string message, EntryType entryType)
        {
            Log(message, string.Empty, string.Empty, entryType);
        }

        public void Log(string message, string applicationName, string userName, EntryType entryType)
        {
            Log(message, applicationName, userName, string.Empty, entryType);
        }

        public void Log(string message, string applicationName, string userName, string ipAddress, EntryType entryType)
        {
            Log(new Log()
                {
                    ApplicationName = applicationName,
                    Message = message,
                    UserName = userName,
                    IpAddress = ipAddress,
                    EnteredOn = DateTime.Now,
                    Type = entryType
                });
        }

        public void Log(Log log)
        {
            var message = string.Format("{0} - {1}: {2}", DateTime.Now, log.ApplicationName, log.Message);
            Trace.WriteLine(message);
        }

        public void LogWithFormat(string message, params object[] args)
        {
            Log(string.Format(message, args));
        }

        public void LogException(Exception ex)
        {
            var output = new StringBuilder();
            var exception = ex;
            while (exception.InnerException != null)
            {
                output.AppendLine(exception.Message);
                exception = exception.InnerException;
            }

            Log(output.ToString(), EntryType.Error);
        }

        public async Task LogAsync(string message)
        {
            await LogAsync(message, EntryType.Information);
        }

        public async Task LogAsync(string message, EntryType entryType)
        {
            await LogAsync(message, string.Empty, string.Empty, entryType);
        }

        public async Task LogAsync(string message, string applicationName, string userName, EntryType entryType)
        {
            await LogAsync(message, applicationName, userName, string.Empty, entryType);
        }

        public async Task LogAsync(string message, string applicationName, string userName, string ipAddress, EntryType entryType)
        {
            await LogAsync(new Log()
                           {
                               ApplicationName = applicationName,
                               Message = message,
                               UserName = userName,
                               IpAddress = ipAddress,
                               EnteredOn = DateTime.Now,
                               Type = entryType
                           });
        }

        public async Task LogAsync(Log log)
        {
            try
            {
                var message = string.Format("{0} - {1}: {2}", DateTime.Now, log.ApplicationName, log.Message);
                Trace.WriteLine(message);
                await TaskHelpers.Empty;
            }
            catch { }
        }

        public async Task LogWithFormatAsync(string message, params object[] args)
        {
            await LogAsync(string.Format(message, args));
        }

        public async Task LogExceptionAsync(Exception ex)
        {
            var output = new StringBuilder();
            var exception = ex;
            while (exception.InnerException != null)
            {
                output.AppendLine(exception.Message);
                exception = exception.InnerException;
            }

            await LogAsync(output.ToString(), EntryType.Error);
        }
    }
}