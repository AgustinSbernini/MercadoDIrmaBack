using mercado_dirma_backend.Business;
using mercado_dirma_backend.Models;
using mercado_dirma_backend.Models.RoleDTOs;
using Microsoft.AspNetCore.Mvc; 
using Serilog;
using System.Net;

namespace mercado_dirma_backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        [HttpGet]
        public async Task<RequestResponse<IEnumerable<Models.Role>>> GetAll()
        {
            var role = new RoleBusiness();

            var result = new RequestResponse<IEnumerable<Models.Role>>();

            try
            {
                result.Data = await role.GetAll();
                result.StatusCode = HttpStatusCode.OK;
                result.Success = true;
            }
            catch (Exception ex)
            {
                Log.Error("Controller: {controller} - EndPoint: {endpoint} - Exception: {ex}", ControllerContext.ActionDescriptor.ControllerName, ControllerContext.ActionDescriptor.ActionName, ex.Message);
                result.Message = ex.Message;
                result.StatusCode = HttpStatusCode.BadRequest;
                result.Success = false;
            }

            return result;
        }

        [HttpGet]
        public async Task<RequestResponse<IEnumerable<GetUserRolesDTO>>> GetRolesByUser(int idUser)
        {
            var role = new RoleBusiness();

            var result = new RequestResponse<IEnumerable<GetUserRolesDTO>>();

            try
            {
                result.Data = await role.GetRolesByUser(idUser);
                result.StatusCode = HttpStatusCode.OK;
                result.Success = true;
            }
            catch (Exception ex)
            {
                Log.Error("Controller: {controller} - EndPoint: {endpoint} - Exception: {ex}", ControllerContext.ActionDescriptor.ControllerName, ControllerContext.ActionDescriptor.ActionName, ex.Message);
                result.Message = ex.Message;
                result.StatusCode = HttpStatusCode.BadRequest;
                result.Success = false;
            }

            return result;
        }

    }
}
