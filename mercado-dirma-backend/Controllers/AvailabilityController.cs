using mercado_dirma_backend.Business;
using mercado_dirma_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace mercado_dirma_backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AvailabilityController : ControllerBase
    {
        [HttpGet]
        public async Task<RequestResponse<IEnumerable<Availability>>> GetAll(bool isActive)
        {
            var availabilityBusiness = new AvailabilityBusiness();

            var result = new RequestResponse<IEnumerable<Availability>>();

            try
            {
                result.Data = await availabilityBusiness.GetAll(isActive);
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
        [HttpPost]
        public async Task<RequestResponse<bool>> Insert(Availability availability)
        {
            var availabilityBusiness = new AvailabilityBusiness();

            var result = new RequestResponse<bool>();

            try
            {
                result.Data = await availabilityBusiness.Insert(availability);
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
        public async Task<RequestResponse<bool>> Delete(int idAvailability)
        {
            var availabilityBusiness = new AvailabilityBusiness();

            var result = new RequestResponse<bool>();

            try
            {
                result.Data = await availabilityBusiness.Delete(idAvailability);
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
        public async Task<RequestResponse<bool>> Update(Availability availability)
        {
            var availabilityBusiness = new AvailabilityBusiness();

            var result = new RequestResponse<bool>();

            try
            {
                result.Data = await availabilityBusiness.Update(availability);
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
