using System.Threading.Tasks;
using Streamline.Logging.Helpers;
using Streamline.Logging.Infrastructure;
using Streamline.Logging.Models;

namespace Streamline.Logging
{
    public class DefaultEmptyLogger : AbstractLogger, ILogger
    {
        protected override async Task SaveAsync(Log log)
        {
            await TaskHelpers.Empty;
        }
    }
}