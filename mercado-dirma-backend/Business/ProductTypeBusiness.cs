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
    }
}
