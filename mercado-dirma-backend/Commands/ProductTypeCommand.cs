using Dapper;
using mercado_dirma_backend.DataAccess;
using mercado_dirma_backend.Models;

namespace mercado_dirma_backend.Commands
{
    public class ProductTypeCommand:DaoBase
    {
        public static async Task<bool> Insert(ProductType productType)
        {
            var sql = @"
                INSERT INTO ProductType
                    (Name, Active)
                VALUES (@Name, 1)";

            using (var db = GetConection())
            {
                return await db.ExecuteAsync(sql, new { productType.Name }) == 1;
            }
        }
        public static async Task<bool> Delete(int idProductType)
        {
            var sql = @"
                UPDATE ProductType
                SET Active = 0 
                WHERE IdProductType = @IdProductType";

            using (var db = GetConection())
            {
                return await db.ExecuteAsync(sql, new { IdProductType = idProductType }) == 1;
            }
        }
        public static async Task<bool> Update(ProductType productType)
        {
            var sql = @"
                UPDATE ProductType 
                SET Name = @Name
                    , Active = @Active
                WHERE IdProductType = @IdProductType";

            using (var db = GetConection())
            {
                return await db.ExecuteAsync(sql, new { productType.IdProductType, productType.Name, productType.Active }) == 1;
            }
        }
    }
}
