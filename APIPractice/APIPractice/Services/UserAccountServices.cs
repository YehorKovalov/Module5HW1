using System.Threading.Tasks;
using APIPractice.Helpers;
using APIPractice.Models;
using APIPractice.Services.Abstractions;

namespace APIPractice.Services
{
    public class UserAccountServices : BaseHttpMethods, IUserAccountServices
    {
        private readonly IConfigurationServices _configurationServices;
        private readonly string _siteUrl;

        public UserAccountServices(IConfigurationServices configurationServices)
        {
            _configurationServices = configurationServices;
            _siteUrl = _configurationServices.TestAPISite;
        }

        public async Task<UserAccount> LoginOrNull(UserAccount account)
        {
            if (account == null)
            {
                return null;
            }

            var result = await PostAsyncOrNull(account, $"{_siteUrl}/api/login");
            if (result == null)
            {
                return null;
            }

            result.Email = account.Email;
            result.Password = account.Password;
            return result;
        }

        public async Task<UserAccount> RegisterUserAccountOrNull(UserAccount account)
        {
            if (account == null)
            {
                return null;
            }

            var result = await PostAsyncOrNull(account, $"{_siteUrl}/api/login");

            if (result == null)
            {
                return null;
            }

            result.Email = account.Email;
            result.Password = account.Password;
            return result;
        }
    }
}
