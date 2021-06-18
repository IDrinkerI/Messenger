using Messenger.Model;
using System.Threading.Tasks;

namespace Messenger.Service
{
    public interface IProfileService
    {
        Task<ProfileModel> GetProfile(int id);
        Task UpdateProfile(int id, ProfileModel value);
    }
}