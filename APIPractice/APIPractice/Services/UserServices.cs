using System.Collections.Generic;
using System.Threading.Tasks;
using APIPractice.Helpers;
using APIPractice.Models;
using APIPractice.Models.Responces;
using APIPractice.Services.Abstractions;

namespace APIPractice.Services
{
    public class UserServices : BaseHttpMethods, IUserServices
    {
        private readonly IConfigurationServices _configurationServices;
        private readonly string _siteUrl;

        public UserServices(IConfigurationServices configurationServices)
        {
            _configurationServices = configurationServices;
            _siteUrl = _configurationServices.TestAPISite;
        }

        public async Task<IEnumerable<User>> GetUsersOrNull()
        {
            var response = await GetAsyncOrNull<PageResponse<List<User>>>($"{_siteUrl}/api/users?page=2");
            return response?.Data;
        }

        public async Task<User> GetUserByIdOrNull(int id)
        {
            if (id < 0)
            {
                return null;
            }

            var response = await GetAsyncOrNull<DataSupportResponse<User>>($"{_siteUrl}/api/users/{id}");
            return response?.Data;
        }

        public async Task<UserDetailDTO> CreateUser(UserDetailDTO user)
        {
            if (user == null)
            {
                return null;
            }

            return await PostAsyncOrNull(user, $"{_siteUrl}/api/users");
        }

        public async Task<UserDetailDTO> PatchUpdateUser(UserDetailDTO user)
        {
            if (user == null && user.Id < 0)
            {
                return null;
            }

            return await PatchAsyncOrNull(user, $"{_siteUrl}/api/users/{user.Id}");
        }

        public async Task<UserDetailDTO> PutUpdateUser(UserDetailDTO user)
        {
            if (user == null && user.Id < 0)
            {
                return null;
            }

            return await PutAsyncOrNull(user, $"{_siteUrl}/api/users/{user.Id}");
        }

        public async Task<User> DeleteUser(int id)
        {
            if (id < 0)
            {
                return null;
            }

            return await DeleteAsyncOrNull<User>($"{_siteUrl}/api/users/{id}");
        }
    }
}
