using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var oracleConnection = new OracleConnection("Oracle connection string");
            var oracleCommand = new DbCommand(oracleConnection, "Oracle instruction");
            oracleCommand.Execute();

            var sqlConnection = new SqlConnection("SQL connection string");
            var sqlCommand = new DbCommand(sqlConnection, "SQL instruction");
            sqlCommand.Execute();
        }
    }
}
