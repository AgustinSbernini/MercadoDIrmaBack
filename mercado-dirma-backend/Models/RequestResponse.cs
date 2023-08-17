using System.Net;

namespace mercado_dirma_backend.Models
{
    public class RequestResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool Success { get; set; }
        public T Data { get; set; }
    }
}
