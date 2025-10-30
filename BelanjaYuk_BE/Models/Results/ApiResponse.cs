using Microsoft.Identity.Client;

namespace BelanjaYuk_BE.Models.Results
{
    public class ApiResponse<T>
    {
        public ApiResponse()
        {
        }
        public int StatusCode { get; set; }
        public string RequestMethod{ get; set; }
        public T Data { get; set;}
    }
}
