using mercado_dirma_backend.Business;
using mercado_dirma_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace mercado_dirma_backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductBrandController : ControllerBase
    {
        [HttpGet]
        public async Task<RequestResponse<IEnumerable<ProductBrand>>> GetAll(bool isActive)
        {
            var productBrand = new ProductBrandBusiness();

            var result = new RequestResponse<IEnumerable<ProductBrand>>();

            try
            {
                result.Data = await productBrand.GetAll(isActive);
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
        public async Task<RequestResponse<ProductBrand>> GetById(int idProductBrand)
        {
            var productBrand = new ProductBrandBusiness();

            var result = new RequestResponse<ProductBrand>();
            
            try
            {
                result.Data = await productBrand.GetById(idProductBrand);
                if(result.Data is null)
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

        [HttpPost]
        public async Task<RequestResponse<bool>> Insert(ProductBrand productName)
        {
            var productBrand = new ProductBrandBusiness();

            var result = new RequestResponse<bool>();

            try
            {
                result.Data = await productBrand.Insert(productName);
                if (!result.Data)
                {
                    result.StatusCode = HttpStatusCode.BadRequest;
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
        [HttpPut]
        public async Task<RequestResponse<bool>> Delete(int idProductBrand)
        {
            var productBrand = new ProductBrandBusiness();

            var result = new RequestResponse<bool>();

            try
            {
                result.Data = await productBrand.Delete(idProductBrand);
                if (!result.Data)
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
        [HttpPut]
        public async Task<RequestResponse<bool>> Update(ProductBrand productName)
        {
            var productBrand = new ProductBrandBusiness();

            var result = new RequestResponse<bool>();

            try
            {
                result.Data = await productBrand.Update(productName);
                if (!result.Data)
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
