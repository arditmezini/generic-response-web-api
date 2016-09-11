using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using GenericResponseAPI.Models;

namespace GenericResponseAPI.ResponseHandler
{
    public class ResponseHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var watcher = Stopwatch.StartNew();
            var response = await base.SendAsync(request, cancellationToken);
            watcher.Stop();

            return BuildApiResponse(request, response, watcher.ElapsedMilliseconds.ToString());
        }

        private static HttpResponseMessage BuildApiResponse(HttpRequestMessage request, HttpResponseMessage response, string responseTime)
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
            var newResponse = request.CreateResponse(response.StatusCode, new APIResponse(response.StatusCode, content, errorMessage, response.IsSuccessStatusCode, responseTime));

            foreach (var header in response.Headers)
            {
                newResponse.Headers.Add(header.Key, header.Value);
            }

            return newResponse;
        }
    }
}