using System.Net;

namespace TickTick.Api.ResponseWrappers
{
    public class Response<T>
    {
        public T Data { get; set; }
        public string[] Errors { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }

        public Response() { }
        public Response(T data) : this(data, HttpStatusCode.OK, null, null) { }
        public Response(T data, HttpStatusCode status) : this(data, status, null, null) {}
        public Response(T data, HttpStatusCode status, string message) :this(data, status, message, null) {}
        public Response(T data, HttpStatusCode status, string message,string[] errors) 
        {
            this.Data = data;
            this.StatusCode = status;
            this.Message = message;
            this.Errors = errors;
        }
    }
}
