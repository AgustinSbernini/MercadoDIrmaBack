using mercado_dirma_backend.Business;
using mercado_dirma_backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace mercado_dirma_backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {


        [HttpGet]
        public async Task<RequestResponse<IEnumerable<ProductType>>> GetAll(bool isActive)
        {
            var productType = new ProductTypeBusiness();

            var result = new RequestResponse<IEnumerable<ProductType>>();

            try
            {
                    result.Data = await productType.GetAll(isActive);
                    result.StatusCode = HttpStatusCode.OK;
                    result.Success = true;
                
                
            }
            catch (Exception ex)
            {
                // LOG ex
                result.StatusCode = HttpStatusCode.BadRequest;
                result.Success = false;
            }

            return result;
        }

        [HttpGet]
        public async Task<RequestResponse<ProductType>> GetById(int idProductType)
        {
            var productType = new ProductTypeBusiness();

            var result = new RequestResponse<ProductType>();

            try
            {
                result.Data = await productType.GetById(idProductType);
                if (result.Data is null)
                {
                    result.StatusCode = HttpStatusCode.NotFound;
                    result.Success = false;
                }
                else
                {
                    result.StatusCode = HttpStatusCode.OK;
                    result.Success = true;
                }
            }
            catch (Exception ex)
            {
                // LOG ex
                result.StatusCode = HttpStatusCode.BadRequest;
                result.Success = false;
            }

            return result;
        }

    }
}
