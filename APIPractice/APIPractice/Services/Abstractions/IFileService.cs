using System.Threading.Tasks;

namespace APIPractice.Services.Abstractions
{
    public interface IFileService
    {
        Task<string> ReadAllTestAsyncOrNull(string path);
    }
}