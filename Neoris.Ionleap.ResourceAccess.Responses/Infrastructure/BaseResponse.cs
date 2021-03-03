using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Neoris.Ionleap.ResourceAccess.Responses.Infrastructure
{
    public class BaseResponse<T> where T : class
    {
        public bool Success { get; set; } = true;

        public string Message { get; set; }
        public T Data { get; set; }

        public BaseResponse(T data)
        {
            Data = data;
        }

        public BaseResponse()
        {
            Message = "";
        }

        public BaseResponse(bool success, string message)
        {
            Message = message;
            Success = success;
        }
    }
}
