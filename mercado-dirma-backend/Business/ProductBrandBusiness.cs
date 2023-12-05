using mercado_dirma_backend.Commands;
using mercado_dirma_backend.Models;
using mercado_dirma_backend.Queries;

namespace mercado_dirma_backend.Business
{
    public class ProductBrandBusiness
    {
        public async Task<IEnumerable<ProductBrand>> GetAll(bool isActive)
        {
            return await ProductBrandQuery.GetAll(isActive);
        }
        public async Task<ProductBrand> GetById(int idProductBrand)
        {
            return await ProductBrandQuery.GetById(idProductBrand);
        }
        public async Task<bool> Insert(ProductBrand productBrand)
        {
            return await ProductBrandCommand.Insert(productBrand);
        }
        public async Task<bool> Delete(int idProductBrand)
        {
            return await ProductBrandCommand.Delete(idProductBrand);
        }
        public async Task<bool> Update(ProductBrand productBrand)
        {
            return await ProductBrandCommand.Update(productBrand);
        }
    }
}
