using System.Data.SqlClient;

namespace mercado_dirma_backend.Queries
{
    public class DaoBase
    {
        private static string stringConeccion = @"Server=tcp:lucasanche-server.database.windows.net,1433;Initial Catalog=Mercado_DIrma;Persist Security Info=False;User ID=ls-admin;Password=Grupo13prog;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public static SqlConnection GetConection()
        {
            var db = new SqlConnection(stringConeccion);
            db.Open();
            return db;
        }
    }
}
