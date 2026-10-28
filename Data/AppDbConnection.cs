using System.Configuration;
using System.Data.SqlClient;

namespace ChandrashekharTest.Data
{
    public class AppDbConnection
    {
        
        private readonly string connectionString;

        public AppDbConnection()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString.ToString();
        }

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}