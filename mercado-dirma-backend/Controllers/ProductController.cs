using Microsoft.AspNetCore.Mvc;
using mercado_dirma_backend.Models;
using mercado_dirma_backend.Business;

namespace mercado_dirma_backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            var products = new ProductBusiness();

            return products.GetProducts();
        }
    }
}
