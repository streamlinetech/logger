using System.Collections.Generic;
using System.Linq;
using Streamline.Logging.Models;

namespace Streamline.Logging
{
    public class VerbosityHelper
    {
        public static IEnumerable<EntryType> GetEntityTypesForVerbosity(VerbosityKind kind)
        {
            var excluded = Enumerable.Empty<EntryType>();
            switch (kind)
            {
                case VerbosityKind.Errors:
                    excluded = new[]
                               {
                                   EntryType.Verbose
                               };
                    break;
                case VerbosityKind.Normal:
                    excluded = new[]
                               {
                                   EntryType.Verbose,
                                   EntryType.Error
                               };
                    break;
                case VerbosityKind.Informational:
                    excluded = new[]
                               {
                                   EntryType.Verbose,
                                   EntryType.Error,
                                   EntryType.Warning
                               };
                    break;
                case VerbosityKind.None: { }
                    excluded = new[]
                               {
                                   EntryType.Verbose,
                                   EntryType.Error, 
                                   EntryType.Warning, 
                                   EntryType.Information
                               };

                    break;
            }

            return new[]
                   {
                       EntryType.Error,
                       EntryType.Information,
                       EntryType.Verbose,
                       EntryType.Warning
                   }.Where(t => excluded.Any(ex => ex != t));
        }
    }
}