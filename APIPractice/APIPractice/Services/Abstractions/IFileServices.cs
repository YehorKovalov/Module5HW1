using System.Threading.Tasks;

namespace APIPractice.Services.Abstractions
{
    public interface IFileServices
    {
        Task<string> ReadAllTestAsyncOrNull(string path);
    }
}