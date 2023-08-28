﻿using mercado_dirma_backend.Business;
using mercado_dirma_backend.Models;
using mercado_dirma_backend.Models.UserDTOs;
using Microsoft.AspNetCore.Http;
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
        public async Task<RequestResponse<bool>> Insert(UserInsertDTO userDTO)
        {
            var users = new UserBusiness();

            var result = new RequestResponse<bool>(await users.Insert(userDTO));

            return result;

        }
    }
}
