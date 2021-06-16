using Messenger.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Messenger.DataAccess
{
    public sealed class ProfileRepository : IRepository<ProfileEntity>
    {
        private readonly StoreContext store;

        public ProfileRepository(StoreContext store) => this.store = store;

        async Task IRepository<ProfileEntity>.Add(ProfileEntity item)
        {
            if (item is null) { return; }

            await store.Profiles.AddAsync(item);
            await store.SaveChangesAsync();
        }

        async Task<ProfileEntity> IRepository<ProfileEntity>.Get(int id)
        {
            var profile = await store.Profiles
                .FirstOrDefaultAsync(p => p.Id == id);

            return profile;
        }

        async Task<IEnumerable<ProfileEntity>> IRepository<ProfileEntity>.GetAll()
        {
            var profiles = await store.Profiles
                .ToArrayAsync();

            return profiles;
        }

        async Task IRepository<ProfileEntity>.Update(int id, ProfileEntity newState)
        {
            var profile = store.Profiles.FirstOrDefault(p => p.Id == id);
            if (profile is null) { return; }


            await profile.UpdateState(newState);
            await store.SaveChangesAsync();
        }
    }
}
