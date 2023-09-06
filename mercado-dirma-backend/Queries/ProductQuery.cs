using Dapper;
using mercado_dirma_backend.Models;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using mercado_dirma_backend.Models.ProductDTOs;
using mercado_dirma_backend.DataAccess;

namespace mercado_dirma_backend.Queries
{
    public class ProductQuery : DaoBase
    {
        public static async Task<IEnumerable<ProductGetDTO>> GetAll(bool isActive)
        {
            var sql = new StringBuilder(@"Select p.IdProduct
                    , p.ProductName
                    , p.IdProductBrand 
                    , pb.[Name] as ProductBrandName
                    , p.IdProductStatus 
                    , ps.[Name] as ProductStatusName
                    , p.IdProductType 
                    , pt.[Name] as ProductTypeName
                    , p.IdUserOwner 
                    , us.Email as UserEmail
                    , us.FullName as UserName
                    , p.Price
                    , p.Size
                    , p.[Description]
                    , p.CreationDate
                    , p.DeletionDate
                    , p.UpdateDate
                    , p.Active 

                    From Product p
                    inner join  ProductBrand pb ON p.IdProductBrand = pb.IdProductBrand
                    inner join  ProductStatus ps ON p.IdProductStatus = ps.IdProductStatus
                    inner join  ProductType pt ON p.IdProductType = pt.IdProductType
                    inner join  [User] us ON p.IdUserOwner = us.IdUser
                            ");

            if (isActive)
            {
                sql.Append(" WHERE p.Active = 1 ");
            }

            using (var db = GetConection())
            {
                return await db.QueryAsync<ProductGetDTO>(sql.ToString());
            }
        }


        //public static async Task<Product> GetById(int idProduct)
        //{
        //    var sql = @"Select * From Product WHERE IdProduct=@IdProduct";

        //    using (var db = GetConection())
        //    {
        //        return await db.QueryFirstOrDefaultAsync<Product>(sql, new {IdProduct= idProduct});
        //    }

        //}
        public static async Task<ProductGetDTO> GetById(int idProduct)
        {
            var sql = @"Select p.IdProduct
                    , p.ProductName
                    , p.IdProductBrand 
                    , pb.[Name] as ProductBrandName
                    , p.IdProductStatus 
                    , ps.[Name] as ProductStatusName
                    , p.IdProductType 
                    , pt.[Name] as ProductTypeName
                    , p.IdUserOwner 
                    , us.Email as UserEmail
                    , us.FullName as UserName
                    , p.Price
                    , p.Size
                    , p.[Description]
                    , p.CreationDate
                    , p.DeletionDate
                    , p.UpdateDate
                    , p.Active 

                    From Product p
                    inner join  ProductBrand pb ON p.IdProductBrand = pb.IdProductBrand
                    inner join  ProductStatus ps ON p.IdProductStatus = ps.IdProductStatus
                    inner join  ProductType pt ON p.IdProductType = pt.IdProductType
                    inner join  [User] us ON p.IdUserOwner = us.IdUser
                    Where p.IdProduct = @IdProduct";

            using (var db = GetConection())
            {
                return await db.QueryFirstOrDefaultAsync<ProductGetDTO>(sql, new { IdProduct = idProduct });
            }

        }

    }
}
