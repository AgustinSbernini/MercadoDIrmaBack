using Dapper;
using mercado_dirma_backend.DataAccess;
using mercado_dirma_backend.Models;
using mercado_dirma_backend.Models.ProductDTOs;
using System.Text;

namespace mercado_dirma_backend.Commands
{
    public class ProductCommand: DaoBase
    {
        public static async Task<bool> Insert(ProductInsertDTO product)
        {
            var sql = @"insert into Product 
                (ProductName
                ,IdProductBrand
                ,IdProductStatus
                ,IdProductType
                ,IdUserOwner
                ,Price
                ,Size
                ,[Description]
                ,CreationDate
                ,Active) 
                values 
                (@ProductName,@IdProductBrand,@IdProductStatus,@IdProductType,@IdUserOwner,@Price,@Size,@Description,@CreationDate,1)";


            using (var db = GetConection())
            {
                return await db.ExecuteAsync(sql, 
                    new { product.ProductName,
                           product.IdProductBrand,
                           product.IdProductStatus,
                           product.IdProductType,
                           product.IdUserOwner,
                           product.Price,
                           product.Size,
                           product.Description,
                           CreationDate = DateTime.Now,                                    
                    }) == 1;
            }
        }

        public static async Task<bool> Delete(int idProduct)
        {
            var sql = @"update Product set DeletionDate=@DeletionDate, Active=0 where IdProduct=@IdProduct";

            using (var db = GetConection())
            {
                return await db.ExecuteAsync(sql, new { DeletionDate = DateTime.Now, IdProduct = idProduct }) == 1;
            }
        }

        public static async Task<bool> Update(ProductUpdateDTO product)
        {
            var sql = @"Update Product 
                        set               
                            ProductName=@ProductName,
                            IdProductBrand=@IdProductBrand,
                            IdProductStatus=@IdProductStatus,
                            IdProductType=@IdProductType,
                            IdUserOwner=@IdUserOwner,
                            Price=@Price,
                            Size=@Size,
                            [Description]=@Description,
                            UpdateDate=@UpdateDate                    
                            where IdProduct=@IdProduct";


            using (var db = GetConection())
            {
                return await db.ExecuteAsync(sql,
                    new
                    {
                        product.IdProduct,
                        product.ProductName,
                        product.IdProductBrand,
                        product.IdProductStatus,
                        product.IdProductType,
                        product.IdUserOwner,
                        product.Price,
                        product.Size,
                        product.Description,
                        UpdateDate= DateTime.Now,
                    }) == 1;
            }
        }
    }
}
