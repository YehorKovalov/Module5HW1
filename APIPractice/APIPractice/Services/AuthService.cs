using System.Net.Http;
using System.Threading.Tasks;
using APIPractice.Models;
using APIPractice.Models.Responces;
using APIPractice.Services.Abstractions;

namespace APIPractice.Services
{
    public class AuthService : IUserAccountService
    {
        private readonly IHttpService _httpService;

        public AuthService(IHttpService httpService) => _httpService = httpService;

        public async Task<UserAccountDTO> LoginOrNull(UserAccountDTO account)
        {
            if (account == null)
            {
                return null;
            }

            var result = await _httpService.SendAsync<LoginResponse>($"/api/login", HttpMethod.Post, account);
            if (result == null)
            {
                return null;
            }

            return new UserAccountDTO
            {
                Email = account.Email,
                Password = account.Password,
                Token = result.Token
            };
        }

        public async Task<UserAccountDTO> RegisterUserAccountOrNull(UserAccountDTO account)
        {
            if (account == null)
            {
                return null;
            }

            var result = await _httpService.SendAsync<RegisterResponse>($"/api/register", HttpMethod.Post, account);

            if (result == null)
            {
                return null;
            }

            return new UserAccountDTO
            {
                Email = account.Email,
                Password = account.Password,
                Token = result.Token
            };
        }
    }
}
