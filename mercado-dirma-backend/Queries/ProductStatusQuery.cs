using Dapper;
using mercado_dirma_backend.Models;
using System.Text;

namespace mercado_dirma_backend.Queries
{
    public class ProductStatusQuery: DaoBase
    {
        public static async Task<IEnumerable<ProductStatus>> GetAll(bool isActive)
        {
            var sql = new StringBuilder(@"
                SELECT IdProductStatus
                    , Name
                    , Active
                FROM ProductStatus ");

            if (isActive)
            {
                sql.Append(" WHERE Active = 1 ");
            }

            using (var db = GetConection())
            {
                return await db.QueryAsync<ProductStatus>(sql.ToString());
            }
        }

        public static async Task<ProductStatus> GetById(int idProductStatus)
        {
            var sql = @"
                SELECT IdProductStatus
                    , Name
                    , Active
                FROM ProductStatus
                WHERE IdProductStatus = @IdProductStatus
                    AND Active = 1                   
            ";

            using (var db = GetConection())
            {
                return await db.QueryFirstOrDefaultAsync<ProductStatus>(sql, new { IdProductStatus = idProductStatus });
            }
        }
    }
}
