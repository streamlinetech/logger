using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Streamline.Logging.Helpers;
using Streamline.Logging.Infrastructure;
using Streamline.Logging.Models;

namespace Streamline.Logging
{
    public class SqlServerLogger : AbstractLogger, ILogger
    {
        protected string ConnectionString { get; private set; }

        public SqlServerLogger(string connectionString, string applicationName = null, string userName = null, VerbosityKind verbosity = VerbosityKind.Normal)
            : base(applicationName: applicationName, userName: userName, verbosity: verbosity)
        {
            ConnectionString = connectionString;
            if (string.IsNullOrEmpty(ConnectionString))
                throw new ArgumentNullException("SqlServerLogger requires a ConnectionString");
        }

        protected override async Task SaveAsync(Log log)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    var command = connection.CreateCommand();
                    using (var transaction = command.Transaction)
                    {
                        command.CommandText = "INSERT INTO LOG_LogEntry VALUES (@message, @entryType, @entryDate, @applicationName, @ipAddress, @userName, @createDate)";
                        command.Parameters.AddWithValue("@message", log.ApplicationName);
                        command.Parameters.AddWithValue("@entryType", log.Type.ToString());
                        command.Parameters.AddWithValue("@entryDate", log.EnteredOn);
                        command.Parameters.AddWithValue("@applicationName", log.ApplicationName);
                        command.Parameters.AddWithValue("@ipAddress", log.IpAddress);
                        command.Parameters.AddWithValue("@userName", log.UserName);
                        command.Parameters.AddWithValue("@createDate", DateTime.Now);

                        connection.Open();
                        command.ExecuteNonQuery();
                        transaction.Commit();
                        
                    }
                }
            }
            catch { }

            await TaskHelpers.Empty;
        }
    }
}