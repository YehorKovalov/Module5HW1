using System.Collections.Generic;
using System.Threading.Tasks;
using APIPractice.Models;

namespace APIPractice.Services.Abstractions
{
    public interface IResourceService
    {
        Task<IEnumerable<ResourceDTO>> GetResourcesOrNull();
        Task<ResourceDTO> GetResourceByIdOrNull(int id);
    }
}