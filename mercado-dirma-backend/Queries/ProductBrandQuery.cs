using Dapper;
using mercado_dirma_backend.Models;
using System.Text;

namespace mercado_dirma_backend.Queries
{
    public class ProductBrandQuery : DaoBase
    {
        public static async Task<IEnumerable<ProductBrand>> GetAll(bool isActive)
        {
            var sql = new StringBuilder(@"
                SELECT IdProductBrand
                    , Name
                    , Active
                FROM ProductBrand ");

            if(isActive)
            {
                sql.Append(" WHERE Active = 1 ");
            }

            using(var db = GetConection())
            {
                return await db.QueryAsync<ProductBrand>(sql.ToString());
            }
        }

        public static async Task<ProductBrand> GetById(int idProductBrand)
        {
            var sql = @"
                SELECT IdProductBrand
                    , Name
                    , Active
                FROM ProductBrand
                WHERE IdProductBrand = @IdProductBrand
                    AND Active = 1                   
            ";

            using (var db = GetConection())
            {
                return await db.QueryFirstOrDefaultAsync<ProductBrand>(sql, new { IdProductBrand = idProductBrand });
            }
        }
    }
}
