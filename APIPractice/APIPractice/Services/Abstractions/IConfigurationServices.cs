using APIPractice.Configurations;

namespace APIPractice.Services.Abstractions
{
    public interface IConfigurationServices
    {
        public Config Config { get; }
        public URL URL { get; }
        public string TestAPISite { get; }
    }
}