using mercado_dirma_backend.Business;
using mercado_dirma_backend.Models;
using Microsoft.AspNetCore.Mvc; 
using Serilog;
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
                Log.Error("Controller: {controller} - EndPoint: {endpoint} - Exception: {ex}", ControllerContext.ActionDescriptor.ControllerName, ControllerContext.ActionDescriptor.ActionName, ex.Message);
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
                Log.Error("Controller: {controller} - EndPoint: {endpoint} - Exception: {ex}", ControllerContext.ActionDescriptor.ControllerName, ControllerContext.ActionDescriptor.ActionName, ex.Message);
                result.StatusCode = HttpStatusCode.BadRequest;
                result.Success = false;
            }

            return result;
        }

        [HttpPost]
        public async Task<RequestResponse<bool>> Insert(ProductType productName)
        {
            var  productType = new ProductTypeBusiness();

            var result = new RequestResponse<bool>();

            try
            {
                result.Data = await productType.Insert(productName);
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
                Log.Error("Controller: {controller} - EndPoint: {endpoint} - Exception: {ex}", ControllerContext.ActionDescriptor.ControllerName, ControllerContext.ActionDescriptor.ActionName, ex.Message);
                result.StatusCode = HttpStatusCode.BadRequest;
                result.Success = false;
            }

            return result;
        }

        [HttpPut]
        public async Task<RequestResponse<bool>> Delete(int idProductType)
        {
            var productType = new ProductTypeBusiness();

            var result = new RequestResponse<bool>();

            try
            {
                result.Data = await productType.Delete(idProductType);
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
                Log.Error("Controller: {controller} - EndPoint: {endpoint} - Exception: {ex}", ControllerContext.ActionDescriptor.ControllerName, ControllerContext.ActionDescriptor.ActionName, ex.Message);
                result.StatusCode = HttpStatusCode.BadRequest;
                result.Success = false;
            }

            return result;
        }

        [HttpPut]
        public async Task<RequestResponse<bool>> Update(ProductType productName)
        {
            var productType = new ProductTypeBusiness();

            var result = new RequestResponse<bool>();

            try
            {
                result.Data = await productType.Update(productName);
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
                Log.Error("Controller: {controller} - EndPoint: {endpoint} - Exception: {ex}", ControllerContext.ActionDescriptor.ControllerName, ControllerContext.ActionDescriptor.ActionName, ex.Message);
                result.StatusCode = HttpStatusCode.BadRequest;
                result.Success = false;
            }

            return result;
        }
    }
}
