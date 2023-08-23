using Dapper;
using mercado_dirma_backend.Models;
using mercado_dirma_backend.Queries;

namespace mercado_dirma_backend.Commands
{
    public class ProductStatusCommand: DaoBase
    {
        public static async Task<bool> Insert(ProductStatus productStatus)
        {
            var sql = @"
                INSERT INTO ProductStatus
                    (Name, Active)
                VALUES (@Name, 1)";

            using (var db = GetConection())
            {
                return await db.ExecuteAsync(sql, new { productStatus.Name }) == 1;
            }
        }

        public static async Task<bool> Delete(int idProductStatus)
        {
            var sql = @"
                UPDATE ProductStatus
                SET Active = 0 
                WHERE IdProductStatus = @IdProductStatus";

            using (var db = GetConection())
            {
                return await db.ExecuteAsync(sql, new { IdProductStatus = idProductStatus }) == 1;
            }
        }

        public static async Task<bool> Update(ProductStatus productStatus)
        {
            var sql = @"
                UPDATE ProductStatus 
                SET Name = @Name
                    , Active = @Active
                WHERE IdProductStatus = @IdProductStatus";

            using (var db = GetConection())
            {
                return await db.ExecuteAsync(sql, new { productStatus.IdProductStatus, productStatus.Name, productStatus.Active }) == 1;
            }
        }
    }
}
