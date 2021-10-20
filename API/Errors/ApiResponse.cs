using System;

namespace API.Errors
{
    public class ApiResponse
    {
        public int StatusCode {get; set;}
        public string Message {get; set;}

        public ApiResponse(int statusCode, string message = null )
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessage(StatusCode);
        }

        private string GetDefaultMessage(int statusCode)
        {
            return statusCode switch{
                400 => "Bad Request",
                404 => "Not Found Exception",
                500 => "Error",
                200 => "Ok",
                _ => null
            };
        }
    }
}