using System.Net;

namespace GenericResponseAPI.Models
{
    public class ApiResponse<T>
    {
        public ApiResponse(HttpStatusCode statusCode, T result,ApiLog apiLog, string errorMessage = null, bool success = false, string responseTime = "0")
        {
            StatusCode = (int)statusCode;
            Result = result;
            ApiLog = apiLog;
            ErrorMessage = errorMessage;
            Success = success;
            ResponseTime = responseTime;
        }

        /// <summary>
        /// Version of Api used
        /// </summary>
        public string Version { get { return "1"; } }

        /// <summary>
        /// Status Code of the Request
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Error Code of the Request
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Generic Object served as result
        /// </summary>
        public T Result { get; set; }

        /// <summary>
        /// Response Api time in miliseconds
        /// </summary>
        public string ResponseTime { get; set; }

        /// <summary>
        /// Succes or not
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// API log of the request
        /// </summary>
        public ApiLog ApiLog { get; set; }
    }
}