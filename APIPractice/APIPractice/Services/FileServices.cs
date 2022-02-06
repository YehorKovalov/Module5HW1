using System.IO;
using System.Threading.Tasks;
using APIPractice.Services.Abstractions;

namespace APIPractice.Services
{
    public class FileServices : IFileServices
    {
        public async Task<string> ReadAllTestAsyncOrNull(string path)
        {
            var pathStringIsNotCorrect = string.IsNullOrWhiteSpace(path);
            if (pathStringIsNotCorrect)
            {
                return null;
            }

            return await File.ReadAllTextAsync(path);
        }
    }
}
