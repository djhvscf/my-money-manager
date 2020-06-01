using MyMoneyManager.Models;
using System.Threading.Tasks;

namespace MyMoneyManager.Helpers
{
    public interface ISessionManager
    {
        Task LoginAsync(User user);

        Task LogoutAsync();

        Task<string> GetUserNameLoggedAsync();

        Task ResetLoginInformationAsync();

        Task<bool> IsUserLoggedIn();
    }
}
