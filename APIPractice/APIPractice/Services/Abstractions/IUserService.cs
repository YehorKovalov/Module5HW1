using System.Collections.Generic;
using System.Threading.Tasks;
using APIPractice.Models;
using APIPractice.Models.Requests;
using APIPractice.Models.Responces;

namespace APIPractice.Services.Abstractions
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetUsersOrNull(string query);
        Task<UserDTO> GetUserByIdOrNull(int id);
        Task<UserCreatingResponse> CreateUser(UserCreatingRequest user);
        Task<UserUpdatingResponse> PutUpdateUser(UserUpdatingRequest user);
        Task<UserUpdatingResponse> PatchUpdateUser(UserUpdatingRequest user);
        Task<EmptyDeletedUserResponse> DeleteUserOrNull(int id);
    }
}