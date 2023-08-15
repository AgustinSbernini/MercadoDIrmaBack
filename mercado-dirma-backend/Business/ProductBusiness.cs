using mercado_dirma_backend.Models;
using mercado_dirma_backend.Queries;

namespace mercado_dirma_backend.Business
{
    public class ProductBusiness
    {
        public IEnumerable<Product> GetProducts()
        {
            return ProductQuery.GetProducts();
        }
    }
}
