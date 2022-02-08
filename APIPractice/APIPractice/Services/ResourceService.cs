using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using APIPractice.Models;
using APIPractice.Models.Responces;
using APIPractice.Services.Abstractions;

namespace APIPractice.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IHttpService _httpService;

        public ResourceService(IHttpService httpService) => _httpService = httpService;

        public async Task<ResourceDTO> GetResourceByIdOrNull(int id)
        {
            if (id < 0)
            {
                return null;
            }

            var response = await _httpService.SendAsync<DataSupportResponse<ResourceDTO>>($"/api/unknown/{id}", HttpMethod.Get);
            return response?.Data;
        }

        public async Task<IEnumerable<ResourceDTO>> GetResourcesOrNull()
        {
            var response = await _httpService.SendAsync<PageResponse<IEnumerable<ResourceDTO>>>($"/api/unknown", HttpMethod.Get);
            return response?.Data;
        }
    }
}
