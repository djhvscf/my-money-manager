using MyMoneyManager.Models;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MyMoneyManager.Helpers
{
    public class SessionManager : ISessionManager
    {
        public async Task LoginAsync(User user)
        {
            await SecureStorage.SetAsync(Constants.IsUserLoggedIn, "true");
            //await SecureStorage.SetAsync(Constants.CurrentUserAccessToken, user.AccessToken);
            //await SecureStorage.SetAsync(Constants.CurrentUserName, user.Username);
            await SecureStorage.SetAsync(Constants.CurrentUserId, user.Id.ToString());
        }

        public async Task LogoutAsync()
        {
            await SecureStorage.SetAsync(Constants.IsUserLoggedIn, "false");
            await SecureStorage.SetAsync(Constants.CurrentUserAccessToken, string.Empty);
            await SecureStorage.SetAsync(Constants.CurrentUserName, string.Empty);
            await SecureStorage.SetAsync(Constants.CurrentUserId, string.Empty);
        }

        public Task ResetLoginInformationAsync()
        {
            return LogoutAsync();
        }

        public Task<string> GetUserNameLoggedAsync()
        {
            return SecureStorage.GetAsync(Constants.CurrentUserName);
        }

        public async Task<bool> IsUserLoggedIn()
        {
            return Convert.ToBoolean(await SecureStorage.GetAsync(Constants.IsUserLoggedIn));
        }
    }
}
