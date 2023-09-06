using mercado_dirma_backend.Business;
using mercado_dirma_backend.Models;
using Microsoft.AspNetCore.Mvc; 
using Serilog;
using System.Net;

namespace mercado_dirma_backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductStatusController : ControllerBase
    {
        [HttpGet]
        public async Task<RequestResponse<IEnumerable<ProductStatus>>> GetAll(bool isActive)
        {
            var productStatus = new ProductStatusBusiness();

            var result = new RequestResponse<IEnumerable<ProductStatus>>();

            try
            {
                result.Data = await productStatus.GetAll(isActive);
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
        public async Task<RequestResponse<ProductStatus>> GetById(int idProductStatus)
        {
            var productStatus = new ProductStatusBusiness();

            var result = new RequestResponse<ProductStatus>();

            try
            {
                result.Data = await productStatus.GetById(idProductStatus);
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
        public async Task<RequestResponse<bool>> Insert(ProductStatus productName)
        {
            var productStatus = new ProductStatusBusiness();

            var result = new RequestResponse<bool>();

            try
            {
                result.Data = await productStatus.Insert(productName);
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
        public async Task<RequestResponse<bool>> Delete(int idProductStatus)
        {
            var productStatus = new ProductStatusBusiness();

            var result = new RequestResponse<bool>();

            try
            {
                result.Data = await productStatus.Delete(idProductStatus);
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
        public async Task<RequestResponse<bool>> Update(ProductStatus productName)
        {
            var productStatus = new ProductStatusBusiness();

            var result = new RequestResponse<bool>();

            try
            {
                result.Data = await productStatus.Update(productName);
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
