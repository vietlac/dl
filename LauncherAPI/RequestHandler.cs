using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace VietLacSo2022
{
    public class RequestHandler : HttpClientHandler
    {
        public RequestHandler(CookieContainer cookieContainer)
        {
            CookieContainer = cookieContainer;
            AllowAutoRedirect = true;
            UseCookies = true;
            AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
        }

        private void RemoveMalformAuthorizationHeader(HttpRequestMessage request)
        {
            var authorization = request.Headers.Authorization;
            if (string.IsNullOrEmpty(authorization?.Parameter))
            {
                request.Headers.Authorization = null;
            }
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            RemoveMalformAuthorizationHeader(request);
            var response = await base.SendAsync(request, cancellationToken);
            return response;
        }
    }

    public class RequestLoggingHandler : DelegatingHandler
    {
        private readonly bool _verbose;
        public RequestLoggingHandler(HttpMessageHandler innerHandler, bool verbose = true) : base(innerHandler) {
            _verbose = verbose;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage response = null;
            try
            {
                response = await base.SendAsync(request, cancellationToken);
                return response;
            }
            catch (Exception)
            {
                throw;
            } finally
            {
                if (_verbose)
                {
                    await LogRequest(request);
                    await LogResponse(response);
                }
            }
        }

        private async Task LogRequest(HttpRequestMessage request)
        {
            if (request != null)
            {
                Console.WriteLine();
                Console.WriteLine("=============================== TRACE REQUEST ===================================");
                foreach (var header in request.Headers)
                {
                    Console.WriteLine($"{header.Key}: {string.Join("|", header.Value)}");
                }
                Console.WriteLine($"{request.Method}/{request.Version} {request.RequestUri.ToString()}");
                if (request.Content != null)
                {
                    var reqParams = await request.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(reqParams))
                    {
                        Console.WriteLine(reqParams);
                    }
                }
            }
        }

        private async Task LogResponse(HttpResponseMessage response)
        {
            if (response != null)
            {
                Console.WriteLine("=============================== TRACE RESPONSE ===================================");
                Console.WriteLine($"{response.StatusCode} {response.ReasonPhrase}");
                foreach (var header in response.Headers)
                {
                    Console.WriteLine($"{header.Key}: {string.Join("|", header.Value)}");
                }
                if (response.Content != null)
                {
                    Console.WriteLine("//////");
                    Console.WriteLine(await response.Content.ReadAsStringAsync());
                }
                Console.WriteLine();
            }
        }
    }
}
