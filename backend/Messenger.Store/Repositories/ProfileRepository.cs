using Messenger.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;


namespace Messenger.Data
{
    public sealed class ProfileRepository
    {
        private readonly StoreContext _store;

        public ProfileRepository(StoreContext store)
        {
            _store = store;
        }

        public async Task<Profile> GetProfile(int id) =>
            await _store.Profiles.FirstOrDefaultAsync(p => p.Id == id);

        public async Task<bool> UpdateProfile(int id, Profile newState)
        {
            var profile = _store.Profiles.FirstOrDefault(p => p.Id == id);
            if (profile is null) { return false; }

            profile.CopyFrom(newState);
            await _store.SaveChangesAsync();

            return true;
        }
    }
}
