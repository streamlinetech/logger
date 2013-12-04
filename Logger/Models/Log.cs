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

        public override string ToString()
        {
            return string.Format("Application Name:  {0}, IP Address: {1}, UserName: {2}, Message: {3} ", ApplicationName, IpAddress, UserName, Message);
        }
    }

}