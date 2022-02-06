using System.Collections.Generic;
using System.Threading.Tasks;
using APIPractice.Models;
using APIPractice.Models.Responces;

namespace APIPractice.Services.Abstractions
{
    public interface IUserServices
    {
        Task<IEnumerable<User>> GetUsersOrNull(string query);
        Task<User> GetUserByIdOrNull(int id);
        Task<UserDetailDTO> CreateUser(UserDetailDTO user);
        Task<UserDetailDTO> PutUpdateUser(UserDetailDTO user);
        Task<UserDetailDTO> PatchUpdateUser(UserDetailDTO user);
        Task<User> DeleteUser(int id);
    }
}