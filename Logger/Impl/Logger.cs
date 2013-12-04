using System.Net.Http;
using System.Threading.Tasks;
using Streamline.Logging.Infrastructure;
using Streamline.Logging.Models;

namespace Streamline.Logging
{
    public class Logger : AbstractLogger, ILogger
    {
        public Logger(string loggingUrl, string applicationName, string userName)
            : base(loggingUrl, applicationName, userName)
        {
        }

        public Logger(string loggingUrl)
            : base(loggingUrl)
        {
        }

        public Logger(string loggingUrl, VerbosityKind verbosity)
            : base(loggingUrl, verbosity: verbosity)
        {
        }


        protected override async Task SaveAsync(Log log)
        {
            try
            {
                using (var httpClient = new HttpClient())
                    await httpClient.PostAsJsonAsync(LoggingUrl, log);
            }
            catch { }
        }
    }
}
