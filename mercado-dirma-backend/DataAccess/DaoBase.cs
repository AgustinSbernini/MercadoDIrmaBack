using System.Data.SqlClient;

namespace mercado_dirma_backend.DataAccess
{
    public class DaoBase
    {
        private static string stringConeccion = @"workstation id=mercadodirma.mssql.somee.com;packet size=4096;user id=agustinsbernini_SQLLogin_1;pwd=449o4huunn;data source=mercadodirma.mssql.somee.com;persist security info=False;initial catalog=mercadodirma;TrustServerCertificate=True";

        public static SqlConnection GetConection()
        {
            var db = new SqlConnection(stringConeccion);
            db.Open();
            return db;
        }
    }
}
