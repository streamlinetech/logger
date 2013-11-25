using System;

namespace Streamline.Logging.Models
{
    public class Log
    {
        public string ApplicationName { get; set; }
        public string Message { get; set; }
        public EntryType Type { get; set; }
        public string IpAddress { get; set; }
        public string UserName { get; set; }
        public DateTime EnteredOn { get; set; }
    }
}