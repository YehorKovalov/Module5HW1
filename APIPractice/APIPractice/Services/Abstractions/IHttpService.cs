using System.Net.Http;
using System.Threading.Tasks;

namespace APIPractice.Services.Abstractions
{
    public interface IHttpService
    {
        Task<TResponse> SendAsync<TResponse>(string url, HttpMethod httpMethod, object content = null)
            where TResponse : class, new();
    }
}