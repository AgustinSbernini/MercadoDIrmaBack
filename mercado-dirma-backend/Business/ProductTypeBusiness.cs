using mercado_dirma_backend.Commands;
using mercado_dirma_backend.Models;
using mercado_dirma_backend.Queries;

namespace mercado_dirma_backend.Business
{
    public class ProductTypeBusiness
    {

        public async Task<IEnumerable<ProductType>> GetAll(bool isActive)
        {
            return await ProductTypeQuery.GetAll(isActive);
        }

        public async Task<ProductType> GetById(int idProductType)
        {
            return await ProductTypeQuery.GetById(idProductType);
        }

        public async Task<bool> Insert(ProductType productType)
        {
            return await ProductTypeCommand.Insert(productType);
        }
        public async Task<bool> Delete(int idProductType)
        {
            return await ProductTypeCommand.Delete(idProductType);
        }
        public async Task<bool> Update(ProductType productType)
        {
            return await ProductTypeCommand.Update(productType);
        }
    }
}
