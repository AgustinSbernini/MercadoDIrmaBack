using mercado_dirma_backend.Models;
using System.Text;
using Dapper;
using mercado_dirma_backend.DataAccess;

namespace mercado_dirma_backend.Queries
{
    public class ProductTypeQuery : DaoBase
    {
        public static async Task<IEnumerable<ProductType>> GetAll(bool isActive)
        {
            var sql = new StringBuilder(@"
                SELECT IdProductType
                    , Name
                    , Active
                FROM ProductType ");

            if (isActive)
            {
                sql.Append(" WHERE Active = 1 ");
            }

            using (var db = GetConection())
            {
                return await db.QueryAsync<ProductType>(sql.ToString());
            }
        }

        public static async Task<ProductType> GetById(int idProductType)
        {
            var sql = @"
                SELECT IdProductType
                    , Name
                    , Active
                FROM ProductType
                WHERE IdProductType = @IdProductType
                    AND Active = 1                   
            ";

            using (var db = GetConection())
            {
                return await db.QueryFirstOrDefaultAsync<ProductType>(sql, new { IdProductType = idProductType });
            }
        }
    }
}
