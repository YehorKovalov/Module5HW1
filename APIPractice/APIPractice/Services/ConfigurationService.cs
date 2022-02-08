using System.Threading.Tasks;
using APIPractice.Configurations;
using APIPractice.Services.Abstractions;
using Newtonsoft.Json;

namespace APIPractice.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private const string ConfigPath = "appsettings.json";
        private readonly IFileService _fileServices;
        private Config _config;

        public ConfigurationService(IFileService fileServices)
        {
            _fileServices = fileServices;
            Init().GetAwaiter().GetResult();
        }

        public Config Config => _config;
        public URL URL => Config.URL;
        public string TestAPISite => URL.TestAPISite;

        private async Task Init()
        {
            var configFile = await _fileServices.ReadAllTestAsyncOrNull(ConfigPath);
            _config = JsonConvert.DeserializeObject<Config>(configFile);
        }
    }
}
