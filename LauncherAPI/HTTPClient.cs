using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using Newtonsoft.Json;
using WordPressPCL;

namespace VietLacSo2022
{
    public enum RequestDataType
    {
        None,
        FormUrlEncodedContent,
        StringContent,
        MultiPartFormDataContent
    }

    public sealed class Requestor
    {
        private static readonly object mutex = new object();  
        private static Requestor instance = null;
        public static Requestor Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (mutex)
                        {
                            if (instance == null)
                            {
                                instance = new Requestor();
                            }
                        }
                }
                return instance;
            }
        }
        private static CookieContainer cookieContainer;
        private static HttpMessageHandler clienthandler;

        Requestor() {
            cookieContainer = new CookieContainer();
            clienthandler = new RequestLoggingHandler(new RequestHandler(cookieContainer), true);
            Client = new HttpClient(clienthandler);
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            SetDefaultHeaders(new Dictionary<string, string> { { "User-Agent", "Mozilla/5.0 (compatible; BrainhubBot/1.0; +http://brainhub.vn/bot.html)" } });
            WpClient = new WordPressClient(Client);
        }

        public void SetDefaultHeaders(IEnumerable<KeyValuePair<string, string>> headers)
        {
            if (headers != null && headers.Count() > 0)
            {
                foreach (var header in headers)
                {
                    Client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }
        }

        public string BaseAddress
        {
            get => Client.BaseAddress.ToString();
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    Client.BaseAddress = new Uri(value);
                }
            }
        }

        public WordPressClient WpClient { get; set; }

        public HttpClient Client { get; }

        public async Task<HttpResponseMessage> MakeRequest(
            HttpMethod method, string url, IEnumerable<KeyValuePair<string, string>> reqParams, RequestDataType dataType, IEnumerable<KeyValuePair<string, string>> headers, 
            CancellationToken cancellationToken, string attachFilePath, string fieldName = "file"
        ){
            var request = new HttpRequestMessage(method, url);
            if (headers != null && headers.Count() > 0)
            {
                foreach (var header in headers)
                {
                    if (dataType != RequestDataType.None && header.Key.ToLower() != "content-type")
                    {
                        request.Headers.Add(header.Key, header.Value);
                    }
                }
            }
            if (method == HttpMethod.Get && reqParams != null && reqParams.Count() > 0)
            {
                // GET
                StringBuilder sb = new StringBuilder(url);
                if (url.ElementAt(url.Length - 1) != '?')
                {
                    sb.Append('?');
                }
                foreach (var item in reqParams)
                {
                    sb.AppendFormat("{0}={1}&", item.Key, item.Value);
                }
                request.RequestUri = new Uri(sb.ToString().TrimEnd('&'));
            } else
            {
                // POST, PUT, DELETE
                if (dataType == RequestDataType.FormUrlEncodedContent && reqParams != null && reqParams.Count() > 0)
                {
                    // html form submit
                    var content = new FormUrlEncodedContent(reqParams);
                    request.Content = content;
                } else if (dataType == RequestDataType.MultiPartFormDataContent)
                {
                    // html form upload file
                    var hasContent = false;
                    var content = new MultipartFormDataContent();
                    if (!string.IsNullOrEmpty(attachFilePath) && File.Exists(attachFilePath))
                    {
                        Stream stream = File.OpenRead(attachFilePath);
                        content.Add(new StreamContent(stream), fieldName, Path.GetFileName(attachFilePath));
                        hasContent = true;
                    }
                    if (reqParams != null && reqParams.Count() > 0)
                    {
                        foreach (var item in reqParams)
                        {
                            content.Add(new StringContent(item.Value), item.Key);
                        }
                        hasContent = true;
                    }
                    if (hasContent)
                    {
                        request.Content = content;
                    }
                } else if (dataType == RequestDataType.StringContent && reqParams != null && reqParams.Count() > 0)
                {
                    // common API Restful
                    var content = new StringContent(JsonConvert.SerializeObject(reqParams), Encoding.UTF8, "application/json");
                    request.Content = content;
                }
            }
            var response = await Client.SendAsync(request, cancellationToken);
            return response;
        }

        public async Task<TResponse> DoGet<TResponse>(string url, IEnumerable<KeyValuePair<string, string>> reqParams, double timeoutMs = 15000)
        {
            using (var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromMilliseconds(timeoutMs)))
            {
                try
                {
                    var response = await MakeRequest(HttpMethod.Get, url, reqParams, RequestDataType.None, null, cancellationTokenSource.Token, null);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(data) && typeof(TResponse) == typeof(string))
                    {
                        data = JsonConvert.SerializeObject(data);
                    }
                    return JsonConvert.DeserializeObject<TResponse>(data);
                }
                catch (OperationCanceledException)
                {
                    throw;
                }
            }
        }

        public async Task<TResponse> DoPost<TResponse>(string url, IEnumerable<KeyValuePair<string, string>> reqParams, double timeoutMs = 15000, RequestDataType dataType = RequestDataType.StringContent)
        {
            using (var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromMilliseconds(timeoutMs)))
            {
                try
                {
                    var response = await MakeRequest(HttpMethod.Post, url, reqParams, dataType, null, cancellationTokenSource.Token, null);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(data) && typeof(TResponse) == typeof(string))
                    {
                        data = JsonConvert.SerializeObject(data);
                    }
                    return JsonConvert.DeserializeObject<TResponse>(data);
                }
                catch (OperationCanceledException)
                {
                    throw;
                }
            }
        }

        public async Task<TResponse> DoPut<TResponse>(string url, IEnumerable<KeyValuePair<string, string>> reqParams, double timeoutMs = 15000, RequestDataType dataType = RequestDataType.StringContent)
        {
            using (var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromMilliseconds(timeoutMs)))
            {
                try
                {
                    var response = await MakeRequest(HttpMethod.Put, url, reqParams, dataType, null, cancellationTokenSource.Token, null);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(data) && typeof(TResponse) == typeof(string))
                    {
                        data = JsonConvert.SerializeObject(data);
                    }
                    return JsonConvert.DeserializeObject<TResponse>(data);
                }
                catch (OperationCanceledException)
                {
                    throw;
                }
            }
        }

        public async Task<TResponse> DoDelete<TResponse>(string url, IEnumerable<KeyValuePair<string, string>> reqParams, int timeoutMs = 15000, RequestDataType dataType = RequestDataType.StringContent)
        {
            using (var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromMilliseconds(timeoutMs)))
            {
                try
                {
                    var response = await MakeRequest(HttpMethod.Delete, url, reqParams, dataType, null, cancellationTokenSource.Token, null);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(data) && typeof(TResponse) == typeof(string))
                    {
                        data = JsonConvert.SerializeObject(data);
                    }
                    return JsonConvert.DeserializeObject<TResponse>(data);
                }
                catch (OperationCanceledException)
                {
                    throw;
                }
            }
        }

        public async Task<TResponse> Upload<TResponse>(string url, IEnumerable<KeyValuePair<string, string>> reqParams, CancellationToken cancellationToken, string attachFilePath, string fieldName = "file")
        {
            var response = await MakeRequest(HttpMethod.Post, url, reqParams, RequestDataType.MultiPartFormDataContent, null, cancellationToken, attachFilePath, fieldName);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            if (!string.IsNullOrEmpty(data) && typeof(TResponse) == typeof(string))
            {
                data = JsonConvert.SerializeObject(data);
            }
            return JsonConvert.DeserializeObject<TResponse>(data);
        }

        public async Task<TResponse> Upload<TResponse>(string url, IEnumerable<KeyValuePair<string, string>> reqParams, double timeoutMs, string attachFilePath, string fieldName = "file")
        {
            using (var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromMilliseconds(timeoutMs)))
            {
                try
                {
                    return await Upload<TResponse>(url, reqParams, cancellationTokenSource.Token, attachFilePath, fieldName);
                }
                catch (OperationCanceledException)
                {
                    throw;
                }
            }
        }

        public async Task Download(string url, IEnumerable<KeyValuePair<string, string>> reqParams, CancellationToken cancellationToken, string savedFile)
        {
            var response = await MakeRequest(HttpMethod.Get, url, reqParams, RequestDataType.None, null, cancellationToken, null);
            response.EnsureSuccessStatusCode();
            using (var stream = await response.Content.ReadAsStreamAsync())
            {
                var downloadFile = Path.GetFileName(new Uri(url).AbsolutePath);
                if (savedFile != null)
                {
                    if (File.GetAttributes(savedFile).HasFlag(FileAttributes.Directory))
                    {
                        downloadFile = Path.Combine(savedFile, downloadFile);
                    } else
                    {
                        downloadFile = savedFile;
                    }
                }
                using (var streamWrite = File.OpenWrite(downloadFile))
                {
                    int BUFFER_SIZE = 512;
                    byte[] buffer = new byte[BUFFER_SIZE];
                    bool endRead = false;
                    do
                    {
                        int bytesRead = await stream.ReadAsync(buffer, 0, BUFFER_SIZE, cancellationToken);
                        if (bytesRead > 0)
                        {
                            await streamWrite.WriteAsync(buffer, 0, bytesRead, cancellationToken);
                        }
                        endRead = bytesRead == 0;
                    } while (!endRead);
                }
            }
        }

        public async Task Download(string url, IEnumerable<KeyValuePair<string, string>> reqParams, double timeoutMs, string savedFile)
        {
            using (var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromMilliseconds(timeoutMs)))
            {
                try
                {
                    await Download(url, reqParams, cancellationTokenSource.Token, savedFile);
                }
                catch (OperationCanceledException)
                {
                    throw;
                }
            }
        }
    }
}
