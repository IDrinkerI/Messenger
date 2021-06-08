using Messenger.Store.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace Messenger.Store
{
    public sealed class UserRepository
    {
        private readonly StoreContext _store;

        public UserRepository(StoreContext store)
        {
            _store = store;
        }

        public async Task<bool> CheckPassword(string email, string password)
        {
            var user = await _store.Users.FirstOrDefaultAsync((u) =>
                u.Email == email && u.Password == password);

            if (user is null)
                return false;
            else
                return true;
        }

        public async Task<User> GetUser(string email)
        {
            var user = await _store.Users.FirstOrDefaultAsync(u => u.Email == email);

            return user;
        }

        public async void AddUser(User newUser)
        {
            var newProfile = new Profile()
            {
                Nickname = newUser.Email,
            };

            newUser.Profile = newProfile;
            await _store.Profiles.AddAsync(newProfile);

            await _store.Users.AddAsync(newUser);
            await _store.SaveChangesAsync();
        }
    }
}
