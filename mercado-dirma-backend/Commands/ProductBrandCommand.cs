using Dapper;
using mercado_dirma_backend.Models;
using mercado_dirma_backend.Queries;
using System.Text;

namespace mercado_dirma_backend.Commands
{
    public class ProductBrandCommand : DaoBase
    {
        public static async Task<bool> Insert(ProductBrand productBrand)
        {
            var sql = @"
                INSERT INTO ProductBrand 
                    (Name, Active)
                VALUES (@Name, 1)";

            using (var db = GetConection())
            {
                return await db.ExecuteAsync(sql, new { productBrand.Name }) == 1;
            }
        }
        public static async Task<bool> Delete(int idProductBrand)
        {
            var sql = @"
                UPDATE ProductBrand
                SET Active = 0 
                WHERE IdProductBrand = @IdProductBrand";

            using (var db = GetConection())
            {
                return await db.ExecuteAsync(sql, new { IdProductBrand = idProductBrand }) == 1;
            }
        }
        public static async Task<bool> Update(ProductBrand productBrand)
        {
            var sql = @"
                UPDATE ProductBrand 
                SET Name = @Name
                    , Active = @Active
                WHERE IdProductBrand = @IdProductBrand";

            using (var db = GetConection())
            {
                return await db.ExecuteAsync(sql, new { productBrand.IdProductBrand, productBrand.Name, productBrand.Active }) == 1;
            }
        }
    }
}
