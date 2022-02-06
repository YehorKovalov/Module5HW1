using System.Collections.Generic;
using System.Threading.Tasks;
using APIPractice.Models;

namespace APIPractice.Services.Abstractions
{
    public interface IResourceServices
    {
        Task<IEnumerable<Resource>> GetResourcesOrNull();
        Task<Resource> GetResourceByIdOrNull(int id);
    }
}