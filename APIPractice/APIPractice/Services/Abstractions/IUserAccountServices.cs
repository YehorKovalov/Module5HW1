using System.Threading.Tasks;
using APIPractice.Models;

namespace APIPractice.Services.Abstractions
{
    public interface IUserAccountServices
    {
        Task<UserAccount> RegisterUserAccountOrNull(UserAccount account);
        Task<UserAccount> LoginOrNull(UserAccount account);
    }
}