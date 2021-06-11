using Messenger.Store.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;


namespace Messenger.Store
{
    public sealed class ProfileRepository
    {
        private readonly StoreContext store;

        public ProfileRepository(StoreContext store) => this.store = store;

        public async Task<Profile> GetProfile(int id) =>
            await store.Profiles.FirstOrDefaultAsync(p => p.Id == id);

        public async Task<bool> UpdateProfile(int id, Profile newState)
        {
            var profile = store.Profiles.FirstOrDefault(p => p.Id == id);
            if (profile is null) { return false; }

            profile.CopyFrom(newState);
            await store.SaveChangesAsync();

            return true;
        }
    }
}
