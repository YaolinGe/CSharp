using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    internal class DbCommand
    {
        public DbConnection DbConnection { get; set; }

        public DbCommand(DbConnection dbConnection, string instruction)
        {
            if (dbConnection == null)
                throw new ArgumentException("Connection cannot be null.");

            if (string.IsNullOrWhiteSpace(instruction))
                throw new ArgumentException("Instruction cannot be null or empty.");

            DbConnection = dbConnection;
        }

        public void Execute()
        {
            DbConnection.Open();
            Console.WriteLine("Instruction executed.");
            DbConnection.Close();
        }
    }
}

