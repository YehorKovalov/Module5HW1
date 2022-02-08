using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using APIPractice.Models.Responces;
using APIPractice.Services.Abstractions;
using Newtonsoft.Json;

namespace APIPractice.Services
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _client;
        private readonly IConfigurationService _configurationServices;
        private readonly string _siteUrl;

        public HttpService(IConfigurationService configurationServices)
        {
            _configurationServices = configurationServices;
            _siteUrl = _configurationServices.TestAPISite;
            _client = new HttpClient();
        }

        public async Task<TResponse> SendAsync<TResponse>(string apiUrl, HttpMethod httpMethod, object content = null)
            where TResponse : class, new()
        {
            if (string.IsNullOrWhiteSpace(apiUrl))
            {
                return default(TResponse);
            }

            var fullUrl = $"{_siteUrl}{apiUrl}";
            var httpMessage = FormRequestMessage(content, fullUrl, httpMethod);
            var result = await _client.SendAsync(httpMessage);
            if (result.IsSuccessStatusCode)
            {
                if (result.StatusCode == HttpStatusCode.NoContent)
                {
                    var emptyDeletedModelResponse = new TResponse();
                    return emptyDeletedModelResponse;
                }

                return await GetResponse<TResponse>(result);
            }

            return default(TResponse);
        }

        private HttpRequestMessage FormRequestMessage<T>(T content, string url, HttpMethod httpMethod)
        {
            var httpMessage = new HttpRequestMessage();

            httpMessage.Content ??= GetStringContentOrNull(content);
            httpMessage.RequestUri = new Uri(url);
            httpMessage.Method = httpMethod;
            return httpMessage;
        }

        private StringContent GetStringContentOrNull<T>(T content)
        {
            if (content == null)
            {
                return null;
            }

            var serializedContent = JsonConvert.SerializeObject(content);
            return new StringContent(serializedContent, Encoding.UTF8, "application/json");
        }

        private async Task<T1> GetResponse<T1>(HttpResponseMessage httpResponseMessage)
        {
            var resultContent = await httpResponseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T1>(resultContent);
        }
    }
}
