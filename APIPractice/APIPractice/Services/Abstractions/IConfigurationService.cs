using APIPractice.Configurations;

namespace APIPractice.Services.Abstractions
{
    public interface IConfigurationService
    {
        public Config Config { get; }
        public URL URL { get; }
        public string TestAPISite { get; }
    }
}