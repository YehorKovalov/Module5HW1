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
            services.AddTransient<IFileServices, FileServices>();
            services.AddSingleton<IConfigurationServices, ConfigurationServices>();
            services.AddTransient<IUserServices, UserServices>();
            services.AddTransient<IResourceServices, ResourceServices>();
            services.AddTransient<IUserAccountServices, UserAccountServices>();
            services.AddTransient<Application>();
            return services.BuildServiceProvider();
        }
    }
}
