using System.Collections.Generic;
using System.Threading.Tasks;
using APIPractice.Models;
using APIPractice.Models.Requests;
using APIPractice.Models.Responces;
using APIPractice.Services.Abstractions;

namespace APIPractice
{
    public class Application
    {
        private readonly IUserService _userServices;
        private readonly IResourceService _resourceServices;
        private readonly IUserAccountService _userAccountServices;
        public Application(
            IUserService userServices,
            IResourceService resourceServices,
            IUserAccountService userAccountServices)
        {
            _userServices = userServices;
            _resourceServices = resourceServices;
            _userAccountServices = userAccountServices;
        }

        public async Task Run()
        {
            var userForUpdating = new UserUpdatingRequest
            {
                Name = "morpheus",
                Job = "zion resident",
            };

            var userForCreating = new UserCreatingRequest
            {
                Name = "morpheus",
                Job = "leader"
            };

            var accountForSuccessfulRegistration = new UserAccountDTO
            {
                Email = "eve.holt@reqres.in",
                Password = "pistol"
            };

            var accountForSuccessfulLogin = new UserAccountDTO
            {
                Email = "eve.holt@reqres.in",
                Password = "cityslicka"
            };

            var accountForUnsuccessfulRegistration = new UserAccountDTO
            {
                Email = "sydney@fife",
            };

            var accountForUnsuccessfulLogin = new UserAccountDTO
            {
                Email = "peter@klaven",
            };

            var taskList = new List<Task>();
            taskList.Add(_userServices.GetUsersOrNull("page=2"));
            taskList.Add(_userServices.GetUserByIdOrNull(2));
            taskList.Add(_userServices.GetUserByIdOrNull(23));
            taskList.Add(_userServices.CreateUser(userForCreating));
            taskList.Add(_userServices.PutUpdateUser(userForUpdating));
            taskList.Add(_userServices.PatchUpdateUser(userForUpdating));
            taskList.Add(_userServices.DeleteUserOrNull(2));

            taskList.Add(_resourceServices.GetResourcesOrNull());
            taskList.Add(_resourceServices.GetResourceByIdOrNull(2));
            taskList.Add(_resourceServices.GetResourceByIdOrNull(23));

            taskList.Add(_userAccountServices.RegisterUserAccountOrNull(accountForSuccessfulRegistration));
            taskList.Add(_userAccountServices.LoginOrNull(accountForSuccessfulLogin));

            taskList.Add(_userAccountServices.RegisterUserAccountOrNull(accountForUnsuccessfulRegistration));
            taskList.Add(_userAccountServices.LoginOrNull(accountForUnsuccessfulLogin));

            taskList.Add(_userServices.GetUsersOrNull("delay=3"));

            await Task.WhenAll(taskList);
        }
    }
}
