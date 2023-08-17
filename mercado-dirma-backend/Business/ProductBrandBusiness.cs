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
    }
}
