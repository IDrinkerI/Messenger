using Messenger.Data;
using Messenger.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Messenger.DataAccess
{
    public sealed class UserRepository : IUserRepository<UserEntity>
    {
        private readonly StoreContext store;

        public UserRepository(StoreContext store)
        {
            this.store = store;
        }

        async Task<UserEntity> IRepository<UserEntity>.Get(int id)
        {
            var user = await store.Users
                .FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        async Task IRepository<UserEntity>.Add(UserEntity item)
        {
            var newProfile = new ProfileEntity { Nickname = item.Email, };
            item.Profile = newProfile;

            await store.Users.AddAsync(item);
            await store.SaveChangesAsync();
        }

        async Task IRepository<UserEntity>.Update(int id, UserEntity newState)
        {
            var user = await store.Users
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user is null) { return; }

            await user.UpdateState(newState);
            await store.SaveChangesAsync();
        }

        Task<IEnumerable<UserEntity>> IRepository<UserEntity>.GetAll()
        {
            throw new System.NotImplementedException();
        }

        async Task<UserEntity> IUserRepository<UserEntity>.Get(string email)
        {
            var user = await store.Users
                .FirstOrDefaultAsync(u => u.Email == email);

            return user;
        }
    }
}
