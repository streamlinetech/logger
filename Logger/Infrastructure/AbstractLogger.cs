using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Streamline.Logging.Helpers;
using Streamline.Logging.Models;

namespace Streamline.Logging.Infrastructure
{
    public abstract class AbstractLogger : ILogger
    {
        protected VerbosityKind Verbosity { get; set; }
        protected string LoggingUrl { get; private set; }
        protected string ApplicationName { get; private set; }
        protected string UserName { get; private set; }

        IEnumerable<EntryType> LoggedEntityTypes
        {
            get
            {
                return VerbosityHelper.GetEntityTypesForVerbosity(Verbosity);
            }
        }

        public AbstractLogger(string loggingUrl = null, string applicationName = null, string userName = null, VerbosityKind verbosity = VerbosityKind.Normal)
        {
            LoggingUrl = loggingUrl;
            ApplicationName = applicationName;
            UserName = userName;
            Verbosity = verbosity;
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

        public void Log(string message, string applicationName, string userName, string ipAddress, EntryType entryType)
        {
            var logs = FormatLogMessageToBreakApartBigMessages(message, applicationName, userName, entryType, ipAddress).ToList();
            foreach (var log in logs)
                SaveAsync(log).Wait();
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

        public async Task LogAsync(string message)
        {
            await LogAsync(message, EntryType.Information);
        }

        public async Task LogAsync(string message, EntryType entryType)
        {
            await LogAsync(message, ApplicationName, UserName, entryType);
        }

        public async Task LogAsync(string message, string applicationName, string userName, EntryType entryType)
        {
            await LogAsync(message, applicationName, userName, string.Empty, entryType);
        }

        public async Task LogAsync(string message, string applicationName, string userName, string ipAddress, EntryType entryType)
        {
            if (CanSaveLogPerVerbosity(entryType))
            {
                var logs = FormatLogMessageToBreakApartBigMessages(message, applicationName, userName, entryType, ipAddress).ToList();
                foreach (var log in logs)
                    await SaveAsync(log);
            }
            else
                await TaskHelpers.Empty;
        }

        public async Task LogAsync(Log log)
        {
            await LogAsync(log.Message, log.ApplicationName, log.UserName, log.IpAddress, log.Type);
        }

        public async Task LogWithFormatAsync(string message, params object[] args)
        {
            await LogAsync(string.Format(message, args));
        }

        public async Task LogExceptionAsync(Exception ex)
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

                await LogAsync(output.ToString(), EntryType.Error);
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
                yield return new Log()
                             {
                                 ApplicationName = applicationName,
                                 EnteredOn = DateTime.Now,
                                 Message = new string(logMessage.Skip(i * 4000).Take(4000).ToArray()),
                                 Type = entryType,
                                 UserName = userName,
                                 IpAddress = ipAddress
                             };
        }

        protected abstract Task SaveAsync(Log log);

        bool CanSaveLogPerVerbosity(EntryType entryType)
        {
            return LoggedEntityTypes.Contains(entryType);
        }
    }
}