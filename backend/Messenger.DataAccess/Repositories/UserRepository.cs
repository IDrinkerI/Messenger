using Messenger.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Messenger.DataAccess
{
    public sealed class UserRepository : IUserRepository<UserEntity>
    {
        private readonly StoreContext store;

        public UserRepository(StoreContext store) => this.store = store;

        async Task<bool> IRepository<UserEntity>.Add(UserEntity item)
        {
            if (item is null)
                return false;

            var newProfile = new ProfileEntity { Nickname = item.Email, };
            item.Profile   = newProfile;

            await store.Users.AddAsync(item);
            await store.SaveChangesAsync();
            return true;
        }

        async Task<UserEntity> IUserRepository<UserEntity>.Get(string email)
        {
            var user = await store.Users
                .FirstOrDefaultAsync(u => u.Email == email);

            return user;
        }

        async Task<UserEntity> IRepository<UserEntity>.Get(int id)
        {
            var user = await store.Users
                .FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        Task<IEnumerable<UserEntity>> IRepository<UserEntity>.GetAll()
        {
            throw new System.NotImplementedException();
        }

        async Task IRepository<UserEntity>.Update(int id, UserEntity newState)
        {
            var user = await store.Users
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user is null) { return; }

            await user.UpdateState(newState);
            await store.SaveChangesAsync();
        }
    }
}
