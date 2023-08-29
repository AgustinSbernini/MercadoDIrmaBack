using mercado_dirma_backend.Business;
using mercado_dirma_backend.Models;
using Microsoft.AspNetCore.Mvc;

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

            var result = new RequestResponse<IEnumerable<User>>(await users.GetAll(isActive));

            return result;
        }

        [HttpGet]
        public async Task<RequestResponse<User>> GetById(int IdUser)
        {
            var users = new UserBusiness();

            var result = new RequestResponse<User>(await users.GetById(IdUser), false);

            return result;
        }

        [HttpPost]
        public async Task<RequestResponse<bool>> Insert(int idUser, string email, string fullName, string password, int dni, DateTime birthDate, long phoneNumber, string address, DateTime creationDate, DateTime deletionDate, DateTime updateDate, bool active)
        {
            var users = new UserBusiness();

            var result = new RequestResponse<bool>(await users.Insert(idUser, email, fullName, password, dni, birthDate, phoneNumber, address, creationDate, deletionDate, updateDate, active));

            return result;
        }
    }
}
