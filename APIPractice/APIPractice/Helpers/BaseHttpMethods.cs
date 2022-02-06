using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using APIPractice.Models;
using APIPractice.Services.Abstractions;
using Newtonsoft.Json;

namespace APIPractice.Helpers
{
    public abstract class BaseHttpMethods
    {
        protected async Task<T> GetAsyncOrNull<T>(string url) => await SendAsyncOrNull(default(T), url, HttpMethod.Get);
        protected async Task<T> PostAsyncOrNull<T>(T content, string url) => await SendAsyncOrNull(content, url, HttpMethod.Post);
        protected async Task<T> PutAsyncOrNull<T>(T content, string url) => await SendAsyncOrNull(content, url, HttpMethod.Put);
        protected async Task<T> PatchAsyncOrNull<T>(T content, string url) => await SendAsyncOrNull(content, url, HttpMethod.Patch);
        protected async Task<T> DeleteAsyncOrNull<T>(string url) => await SendAsyncOrNull(default(T), url, HttpMethod.Delete);

        private async Task<T> SendAsyncOrNull<T>(T content, string url, HttpMethod httpMethod)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return default(T);
            }

            using (var client = new HttpClient())
            {
                var httpMessage = FormRequestMessage(content, url, httpMethod);
                var result = await client.SendAsync(httpMessage);

                if (result.IsSuccessStatusCode)
                {
                    return await GetResponse<T>(result);
                }
                else
                {
                    var response = await GetResponse<ErrorResponse>(result);
                    Console.WriteLine($"{result.StatusCode}: {response.ErrorMessage}");
                }
            }

            return default(T);
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
