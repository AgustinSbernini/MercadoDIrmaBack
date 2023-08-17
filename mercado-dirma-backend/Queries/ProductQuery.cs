using Dapper;
using mercado_dirma_backend.Models;

namespace mercado_dirma_backend.Queries
{
    public class ProductQuery : DaoBase
    {
        public static IEnumerable<Product> GetProducts()
        {
            var sql = @"
                SELECT IdProduct
                FROM Product
            ";

            using (var conn = GetConection())
            {
                return conn.Query<Product>(sql);
            }
        }
    }
}
