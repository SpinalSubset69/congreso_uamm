using System;

namespace API.Helpers
{
    public class ApiResponseOk
    {
        public int StatusCode {get; set;}
        public string Message {get; set;}
        public Object Data {get; set;}

        public ApiResponseOk(int statusCode, string message, Object data)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessage(StatusCode);
            Data = data;
        }

        private string GetDefaultMessage(int statusCode)
        {
            return statusCode switch{
                200 => "Ok",
                _ => null
            };
        }
    }
}