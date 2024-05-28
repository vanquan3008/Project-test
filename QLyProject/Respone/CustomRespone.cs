using System.Net;

namespace QLyProject.Respone
{
    public class CustomRespone
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string? Message { get; set; }
        public object? Result { get; set; }
    }
}
