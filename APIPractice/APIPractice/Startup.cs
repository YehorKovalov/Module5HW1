using System;
using System.Threading.Tasks;
using APIPractice.Services;
using APIPractice.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace APIPractice
{
    public class Startup
    {
        public async Task Run()
        {
            var servicesProvider = ConfigureServices();
            var app = servicesProvider?.GetService<Application>();
            await app?.Run();
        }

        public IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddTransient<IFileService, FileService>();
            services.AddSingleton<IConfigurationService, ConfigurationService>();
            services.AddSingleton<IHttpService, HttpService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IResourceService, ResourceService>();
            services.AddTransient<IUserAccountService, AuthService>();
            services.AddTransient<Application>();
            return services.BuildServiceProvider();
        }
    }
}
