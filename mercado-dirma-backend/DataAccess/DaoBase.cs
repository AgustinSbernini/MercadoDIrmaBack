using System.Data.SqlClient;

namespace mercado_dirma_backend.DataAccess
{
    public class DaoBase
    {
        private static string stringConeccion = @"Server=tcp:mercadodirma.mssql.somee.com,1433;Initial Catalog=mercadodirma;Persist Security Info=False;User ID=agustinsbernini_SQLLogin_1;Password=449o4huunn;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=60;";

        public static SqlConnection GetConection()
        {
            var db = new SqlConnection(stringConeccion);
            db.Open();
            return db;
        }
    }
}
