using mercado_dirma_backend.Business;
using mercado_dirma_backend.Models.Transaction;
using mercado_dirma_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace mercado_dirma_backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        [HttpGet]
        public async Task<RequestResponse<IEnumerable<Transaction>>> GetAll(bool isActive)
        {
            var transaction = new TransactionBusiness();

            var result = new RequestResponse<IEnumerable<Transaction>>();

            try
            {
                result.Data = await transaction.GetAll(isActive);
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
        public async Task<RequestResponse<Transaction>> GetById(int idTransaction)
        {
            var transaction = new TransactionBusiness();

            var result = new RequestResponse<Transaction>();

            try
            {
                result.Data = await transaction.GetById(idTransaction);
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
        public async Task<RequestResponse<IEnumerable<Transaction>>> GetByUser(int idUser)
        {
            var transaction = new TransactionBusiness();

            var result = new RequestResponse<IEnumerable<Transaction>>();

            try
            {
                result.Data = await transaction.GetByUser(idUser);
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
        [HttpPost]
        public async Task<RequestResponse<bool>> Insert(TransactionInsertDto transactionDto)
        {
            var transaction = new TransactionBusiness();

            var result = new RequestResponse<bool>();

            try
            {
                result.Data = await transaction.Insert(transactionDto);
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
        public async Task<RequestResponse<bool>> Delete(int idTransaction)
        {
            var transaction = new TransactionBusiness();

            var result = new RequestResponse<bool>();

            try
            {
                result.Data = await transaction.Delete(idTransaction);
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
        public async Task<RequestResponse<bool>> Update(TransactionUpdateDto transactionDto)
        {
            var transaction = new TransactionBusiness();

            var result = new RequestResponse<bool>();

            try
            {
                result.Data = await transaction.Update(transactionDto);
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
