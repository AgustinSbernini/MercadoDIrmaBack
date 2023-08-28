using mercado_dirma_backend.Business;
using mercado_dirma_backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace mercado_dirma_backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        [HttpGet]
        public async Task<RequestResponse<IEnumerable<Appointment>>> GetAll(bool isActive)
        {
            var appointmentBusiness = new AppointmentBusiness();

            var result = new RequestResponse<IEnumerable<Appointment>>();

            try
            {
                result.Data = await appointmentBusiness.GetAll(isActive);
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
        public async Task<RequestResponse<Appointment>> GetById(int idAppointment)
        {
            var appointmentBusiness = new AppointmentBusiness();

            var result = new RequestResponse<Appointment>();

            try
            {
                result.Data = await appointmentBusiness.GetById(idAppointment);
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
        [HttpGet]
        public async Task<RequestResponse<IEnumerable<Appointment>>> GetByUser(int idUser, bool isActive)
        {
            var appointmentBusiness = new AppointmentBusiness();

            var result = new RequestResponse<IEnumerable<Appointment>>();

            try
            {
                result.Data = await appointmentBusiness.GetByUser(idUser, isActive);
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
        public async Task<RequestResponse<bool>> Insert(Appointment appointment)
        {
            var appointmentBusiness = new AppointmentBusiness();

            var result = new RequestResponse<bool>();

            try
            {
                result.Data = await appointmentBusiness.Insert(appointment);
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
        public async Task<RequestResponse<bool>> Delete(int idAppointment)
        {
            var appointmentBusiness = new AppointmentBusiness();

            var result = new RequestResponse<bool>();

            try
            {
                result.Data = await appointmentBusiness.Delete(idAppointment);
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
        public async Task<RequestResponse<bool>> Update(Appointment appointment)
        {
            var appointmentBusiness = new AppointmentBusiness();

            var result = new RequestResponse<bool>();

            try
            {
                result.Data = await appointmentBusiness.Update(appointment);
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
