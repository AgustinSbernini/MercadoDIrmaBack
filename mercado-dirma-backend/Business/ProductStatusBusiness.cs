using mercado_dirma_backend.Commands;
using mercado_dirma_backend.Models;
using mercado_dirma_backend.Queries;

namespace mercado_dirma_backend.Business
{
    public class ProductStatusBusiness
    {
        public async Task<IEnumerable<ProductStatus>> GetAll(bool isActive)
        {
            return await ProductStatusQuery.GetAll(isActive);
        }
        public async Task<ProductStatus> GetById(int idProductStatus)
        {
            return await ProductStatusQuery.GetById(idProductStatus);
        }
        public async Task<bool> Insert(ProductStatus productStatus)
        {
            return await ProductStatusCommand.Insert(productStatus);
        }
        public async Task<bool> Delete(int idProductStatus)
        {
            return await ProductStatusCommand.Delete(idProductStatus);
        }
        public async Task<bool> Update(ProductStatus productStatus)
        {
            return await ProductStatusCommand.Update(productStatus);
        }
    }
}
