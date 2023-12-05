using mercado_dirma_backend.Business;
using System.Net;

namespace mercado_dirma_backend.Models
{
    public class RequestResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T Data { get; set; }
        public RequestResponse()
        {

        }
    }
}
