using System.Net;

namespace GenericResponseAPI.Models
{
    public class APIResponse
    {
        public APIResponse(HttpStatusCode statusCode, object result, string errorMessage = null, bool success = false, string responseTime = "0")
        {
            StatusCode = (int)statusCode;
            Result = result;
            ErrorMessage = errorMessage;
            Success = success;
            ResponseTime = responseTime;
        }

        public string Version { get { return "1"; } }
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public object Result { get; set; }
        public string ResponseTime { get; set; }
        public bool Success { get; set; }
    }
}