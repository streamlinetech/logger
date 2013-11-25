using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
    }

    public class Logger : ILogger
    {
        public string LoggingUrl { get; set; }
        public string ApplicationName { get; set; }
        public string UserName { get; set; }

        public Logger(string loggingUrl, string applicationName, string userName)
        {
            LoggingUrl = loggingUrl;
            ApplicationName = applicationName;
            UserName = userName;
        }

        public void Log(string message)
        {
            Log(message, EntryType.Information);
        }

        public void Log(string message, EntryType entryType)
        {
            Log(message, ApplicationName, UserName, entryType);
        }

        public void Log(string message, string applicationName, string userName, EntryType entryType)
        {
            Log(message, applicationName, userName, string.Empty, entryType);
        }

        public async void Log(string message, string applicationName, string userName, string ipAddress, EntryType entryType)
        {
            var logs = FormatLogMessageToBreakApartBigMessages(message, applicationName, userName, entryType, ipAddress).ToList();
            foreach (var log in logs)
                await PostLog(log);
        }

        public void Log(Log log)
        {
            Log(log.Message, log.ApplicationName, log.UserName, log.IpAddress, log.Type);
        }

        public void LogWithFormat(string message, params object[] args)
        {
            Log(string.Format(message, args));
        }

        public void LogException(Exception ex)
        {
            var output = new StringBuilder();
            try
            {
                var exception = ex;
                while (exception.InnerException != null)
                {
                    output.AppendLine(exception.Message);
                    exception = exception.InnerException;
                }

                Log(output.ToString(), EntryType.Error);
            }
            finally
            {
                output = null;
            }
        }

        IEnumerable<Log> FormatLogMessageToBreakApartBigMessages(string message, string applicationName, string userName, EntryType entryType, string ipAddress)
        {
            var logMessage = message;

            for (var i = 0; i < (int)Math.Ceiling(message.Length / 4000f); i++)
            {
                yield return new Log()
                {
                    ApplicationName = applicationName,
                    EnteredOn = DateTime.Now,
                    Message = new string(message.Skip(i * 4000).Take(4000).ToArray()),
                    Type = entryType,
                    UserName = userName,
                    IpAddress = ipAddress
                };
            }
        }

        async Task PostLog(Log log)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    await httpClient.PostAsJsonAsync(LoggingUrl, log);
                }
            }
            catch { }
        }
    }
}