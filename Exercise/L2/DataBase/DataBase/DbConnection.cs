using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    internal class DbConnection
    {
        public string ConnectionString { get; set; }
        public TimeSpan Timeout { get; set; }

        public DbConnection(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("Connection string cannot be null or empty.");

            ConnectionString = connectionString;
        }

        public virtual void Open()
        {
            Console.WriteLine("Database connection opened.");
        }

        public virtual void Close()
        {
            Console.WriteLine("Database connection closed.");
        }
    }
}
