using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using APIPractice.Models;
using APIPractice.Models.Requests;
using APIPractice.Models.Responces;
using APIPractice.Services.Abstractions;

namespace APIPractice.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpService _httpService;

        public UserService(IHttpService httpService) => _httpService = httpService;

        public async Task<IEnumerable<UserDTO>> GetUsersOrNull(string query)
        {
            var response = await _httpService.SendAsync<PageResponse<IEnumerable<UserDTO>>>($"/api/users?{query}", HttpMethod.Get);
            return response?.Data;
        }

        public async Task<UserDTO> GetUserByIdOrNull(int id)
        {
            if (id < 0)
            {
                return null;
            }

            var response = await _httpService.SendAsync<DataSupportResponse<UserDTO>>($"/api/users/{id}", HttpMethod.Get);
            return response?.Data;
        }

        public async Task<UserCreatingResponse> CreateUser(UserCreatingRequest user)
        {
            if (user == null)
            {
                return null;
            }

            return await _httpService.SendAsync<UserCreatingResponse>($"/api/users", HttpMethod.Post, user);
        }

        public async Task<UserUpdatingResponse> PatchUpdateUser(UserUpdatingRequest user)
        {
            if (user == null)
            {
                return null;
            }

            return await _httpService.SendAsync<UserUpdatingResponse>($"/api/users/{user.Id}", HttpMethod.Patch, user);
        }

        public async Task<UserUpdatingResponse> PutUpdateUser(UserUpdatingRequest user)
        {
            if (user == null)
            {
                return null;
            }

            return await _httpService.SendAsync<UserUpdatingResponse>($"/api/users/{user.Id}", HttpMethod.Put, user);
        }

        public async Task<EmptyDeletedUserResponse> DeleteUserOrNull(int id)
        {
            if (id < 0)
            {
                return null;
            }

            return await _httpService.SendAsync<EmptyDeletedUserResponse>($"/api/users/{id}", HttpMethod.Delete);
        }
    }
}
