using mercado_dirma_backend.Business;
using mercado_dirma_backend.Models;
using mercado_dirma_backend.Models.UserDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace mercado_dirma_backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public async Task<RequestResponse<IEnumerable<User>>> GetAll(bool isActive)
        {
            var users = new UserBusiness();

            var result = new RequestResponse<IEnumerable<User>>();

            try
            {
                result.Data = await users.GetAll(isActive);
                result.StatusCode = HttpStatusCode.OK;
                result.Success = true;
            }
            catch (Exception ex)
            {
                // LOG ex
                result.Message = ex.Message;
                result.StatusCode = HttpStatusCode.BadRequest;
                result.Success = false;
            }

            return result;
        }

        [HttpGet]
        public async Task<RequestResponse<User>> GetById(int IdUser)
        {
            var users = new UserBusiness();

            var result = new RequestResponse<User>();

            try
            {
                result.Data = await users.GetById(IdUser);
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
                result.Message = ex.Message;
                result.StatusCode = HttpStatusCode.BadRequest;
                result.Success = false;
            }

            return result;
        }

        [HttpPost]
        public async Task<RequestResponse<bool>> Insert(UserInsertDTO userDTO)
        {
            var users = new UserBusiness();

            var result = new RequestResponse<bool>();

            try
            {
                result.Data = await users.Insert(userDTO);
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
                result.Message = ex.Message;
                result.StatusCode = HttpStatusCode.BadRequest;
                result.Success = false;
            }

            return result;
        }

        [HttpPut]
        public async Task<RequestResponse<bool>> Update(UserUpdateDTO userDTO)
        {
            var users = new UserBusiness();

            var result = new RequestResponse<bool>();

            try
            {
                result.Data = await users.Update(userDTO);
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
                result.Message = ex.Message;
                result.StatusCode = HttpStatusCode.BadRequest;
                result.Success = false;
            }

            return result;

        }

        [HttpPut]
        public async Task<RequestResponse<bool>> Delete(int idUser)
        {
            var userBusiness = new UserBusiness();

            var result = new RequestResponse<bool>();

            try
            {
                result.Data = await userBusiness.Delete(idUser);
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
                result.Message = ex.Message;
                result.StatusCode = HttpStatusCode.BadRequest;
                result.Success = false;
            }

            return result;
        }


    }
}
