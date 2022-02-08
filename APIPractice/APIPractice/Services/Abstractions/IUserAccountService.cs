using System.Threading.Tasks;
using APIPractice.Models;

namespace APIPractice.Services.Abstractions
{
    public interface IUserAccountService
    {
        Task<UserAccountDTO> RegisterUserAccountOrNull(UserAccountDTO account);
        Task<UserAccountDTO> LoginOrNull(UserAccountDTO account);
    }
}