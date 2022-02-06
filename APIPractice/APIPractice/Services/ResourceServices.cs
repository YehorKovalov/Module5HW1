using System.Collections.Generic;
using System.Threading.Tasks;
using APIPractice.Helpers;
using APIPractice.Models;
using APIPractice.Models.Responces;
using APIPractice.Services.Abstractions;

namespace APIPractice.Services
{
    public class ResourceServices : BaseHttpMethods, IResourceServices
    {
        private readonly IConfigurationServices _configurationServices;
        private readonly string _siteUrl;

        public ResourceServices(IConfigurationServices configurationServices)
        {
            _configurationServices = configurationServices;
            _siteUrl = _configurationServices.TestAPISite;
        }

        public async Task<Resource> GetResourceByIdOrNull(int id)
        {
            if (id < 0)
            {
                return null;
            }

            var response = await GetAsyncOrNull<PageResponse<Resource>>($"{_siteUrl}/api/unknown/{id}");
            return response?.Data;
        }

        public async Task<IEnumerable<Resource>> GetResourcesOrNull()
        {
            var response = await GetAsyncOrNull<DataSupportResponse<List<Resource>>>($"{_siteUrl}/api/unknown");
            return response?.Data;
        }
    }
}
