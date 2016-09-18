using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using GenericResponseAPI.Models;
using System.Web;

namespace GenericResponseAPI.ResponseHandler
{
    public class ResponseHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var apiLog = CreateApiLog(request);

            var watcher = Stopwatch.StartNew();
            var response = await base.SendAsync(request, cancellationToken);
            watcher.Stop();

            return BuildApiResponse(request, response, apiLog, watcher.ElapsedMilliseconds.ToString());
        }

        private static HttpResponseMessage BuildApiResponse(HttpRequestMessage request, HttpResponseMessage response, ApiLog apiLog, string responseTime)
        {
            object content;
            string errorMessage = null;

            if (response.TryGetContentValue(out content) && !response.IsSuccessStatusCode)
            {
                var error = content as HttpError;

                if (error != null)
                {
                    content = null;
                    errorMessage = error.Message;
#if DEBUG
                    errorMessage = string.Concat(errorMessage, error.ExceptionMessage, error.StackTrace);
#endif
                }
            }

            apiLog.ResponseStatusCode = (int)response.StatusCode;
            apiLog.ResponseTimestamp = DateTime.Now;

            var apiResponseModel = request.CreateResponse(response.StatusCode, new ApiResponse<object>(response.StatusCode, content, apiLog, errorMessage, response.IsSuccessStatusCode, responseTime));

            foreach (var header in response.Headers)
            {
                apiResponseModel.Headers.Add(header.Key, header.Value);
            }
            return apiResponseModel;
        }

        private static ApiLog CreateApiLog(HttpRequestMessage request)
        {
            var context = ((HttpContextBase)request.Properties["MS_HttpContext"]);

            return new ApiLog
            {
                Application = "[calling application]",
                User = context.User.Identity.Name,
                Machine = Environment.MachineName,
                RequestIpAddress = context.Request.UserHostAddress,
                RequestMethod = request.Method.Method,
                RequestTimestamp = DateTime.Now,
                RequestUri = request.RequestUri.ToString()
            };
        }
    }
}