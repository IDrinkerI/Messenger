using Messenger.Data;
using Messenger.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Messenger.DataAccess
{
    public sealed class UserRepository : IRepository<UserEntity>
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

        async void IRepository<UserEntity>.Add(UserEntity item)
        {
            var newProfile = new ProfileEntity { Nickname = item.Email, };
            item.Profile = newProfile;

            await store.Users.AddAsync(item);
            await store.SaveChangesAsync();
        }

        async void IRepository<UserEntity>.Update(int id, UserEntity newState)
        {
            var user = await store.Users
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user is null) { return; }

            user.UpdateState(newState);
            await store.SaveChangesAsync();
        }

        Task<IEnumerable<UserEntity>> IRepository<UserEntity>.GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
