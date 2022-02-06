using System.Collections.Generic;
using System.Threading.Tasks;
using APIPractice.Models;
using APIPractice.Models.Responces;
using APIPractice.Services.Abstractions;

namespace APIPractice
{
    public class Application
    {
        private readonly IUserServices _userServices;
        private readonly IResourceServices _resourceServices;
        private readonly IUserAccountServices _userAccountServices;
        public Application(
            IUserServices userServices,
            IResourceServices resourceServices,
            IUserAccountServices userAccountServices)
        {
            _userServices = userServices;
            _resourceServices = resourceServices;
            _userAccountServices = userAccountServices;
        }

        public async Task Run()
        {
            var userForUpdating = new UserDetailDTO
            {
                Id = 2,
                Name = "morpheus",
                Job = "zion resident",
            };

            var userForCreating = new UserDetailDTO
            {
                Name = "morpheus",
                Job = "leader"
            };

            var accountForSuccessfulRegistration = new UserAccount
            {
                Email = "eve.holt@reqres.in",
                Password = "pistol"
            };

            var accountForSuccessfulLogin = new UserAccount
            {
                Email = "eve.holt@reqres.in",
                Password = "cityslicka"
            };

            var accountForUnsuccessfulRegistration = new UserAccount
            {
                Email = "sydney@fife",
            };

            var accountForUnsuccessfulLogin = new UserAccount
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
            taskList.Add(_userServices.DeleteUser(2));

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
