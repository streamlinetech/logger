using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Streamline.Logging.Helpers;
using Streamline.Logging.Infrastructure;
using Streamline.Logging.Models;

namespace Streamline.Logging
{
    public class TraceLogger : AbstractLogger, ILogger
    {
        public TraceLogger(VerbosityKind verbosity)
            : base(verbosity: verbosity)
        {
            Verbosity = verbosity;
        }


        protected override async Task SaveAsync(Log log)
        {
            Trace.WriteLine(log);
            await TaskHelpers.Empty;
        }
    }


}