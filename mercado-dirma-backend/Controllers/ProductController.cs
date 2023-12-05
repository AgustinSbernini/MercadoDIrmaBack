using Microsoft.AspNetCore.Mvc; 
using Serilog;
using mercado_dirma_backend.Models;
using mercado_dirma_backend.Business;
using System.Net;
using mercado_dirma_backend.Models.ProductDTOs;

namespace mercado_dirma_backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public async Task<RequestResponse<IEnumerable<ProductGetDTO>>>GetAll(bool isActive)
        {
            var products = new ProductBusiness();
            var result = new RequestResponse<IEnumerable<ProductGetDTO>>();

            try
            {
                result.Data = await products.GetAll(isActive);
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
        public async Task<RequestResponse<ProductGetDTO>> GetById(int idProduct)
        {
            var product = new ProductBusiness();

            var result = new RequestResponse<ProductGetDTO>();

            try
            {
                result.Data = await product.GetById(idProduct);
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
        public async Task<RequestResponse<bool>> Insert(ProductInsertDTO product)
        {
            var _product = new ProductBusiness();

            var result = new RequestResponse<bool>();

            try
            {
                result.Data = await _product.Insert(product);
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
        public async Task<RequestResponse<bool>> Delete(int idProduct)
        {
            var _product = new ProductBusiness();

            var result = new RequestResponse<bool>();

            try
            {
                result.Data = await _product.Delete(idProduct);
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
        public async Task<RequestResponse<bool>> Update(ProductUpdateDTO product)
        {
            var _product = new ProductBusiness();

            var result = new RequestResponse<bool>();

            try
            {
                result.Data = await _product.Update(product);
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
