using System.Data.SqlClient;

namespace mercado_dirma_backend.Queries
{
    public class DaoBase
    {
        private static string stringConeccion = @"Server=tcp:asbernini-db.database.windows.net,1433;Initial Catalog=Mercado_DIrma;Persist Security Info=False;User ID=sa-sysadmin;Password=C0ntr4L0c4!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=60;";

        public static SqlConnection GetConection()
        {
            var db = new SqlConnection(stringConeccion);
            db.Open();
            return db;
        }
    }
}
