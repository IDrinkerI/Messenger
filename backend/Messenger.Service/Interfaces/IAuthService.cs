using Messenger.Model;
using System.Threading.Tasks;


namespace Messenger.Service
{
    public interface IAuthService
    {
        int CurrentUserId { get; }

        Task<bool> AddUser(AuthInfoModel newUser);
        Task<bool> CheckPassword(AuthInfoModel signinData);
        Task<bool> Contains(AuthInfoModel newUser);
    }
}