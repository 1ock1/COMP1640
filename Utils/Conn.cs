using Microsoft.Data.SqlClient;

namespace COMP1640.Utils
{
    public class Conn
    {
        public static SqlConnection Connection()
        {
            SqlConnection conn = new SqlConnection();
            //local
            conn.ConnectionString = "Server=tcp:comp1640-stg.database.windows.net,1433;Initial Catalog=comp1640-stg;Persist Security Info=False;User ID=comp1640-stg;Password=Azuredbstaging252;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            //stg
            //conn.ConnectionString = "Server=tcp:comp1640-stg.database.windows.net,1433;Initial Catalog=comp1640-stg;Persist Security Info=False;User ID=comp1640-stg;Password=Azuredbstaging252;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            return conn;
        }
    }
}
