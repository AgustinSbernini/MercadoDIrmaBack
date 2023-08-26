using mercado_dirma_backend.Business;
using System.Net;

namespace mercado_dirma_backend.Models
{
    public class RequestResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool Success { get; set; }
        public T Data { get; set; }
        public RequestResponse()
        {

        }
        public RequestResponse(T response, bool nulleable = false)
        {
            Data = response;
            if (response is not null)
            {
                StatusCode = HttpStatusCode.OK;
                Success = true;
            }
            else
            {
                //revisar status code 404
                StatusCode = nulleable ? StatusCode = HttpStatusCode.OK : StatusCode = HttpStatusCode.BadRequest;
                Success = nulleable;
            }
        }
    }
}
