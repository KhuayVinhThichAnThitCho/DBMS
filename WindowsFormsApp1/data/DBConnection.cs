using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.data
{
    public class DBConnection
    {
        private static readonly string connectionString =
"Server=localhost,1433;Database=english_academy;User Id=sa;Password=Neymar@050292;TrustServerCertificate=True;";

        public static SqlConnection getConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
