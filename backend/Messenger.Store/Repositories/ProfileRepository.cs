﻿using Messenger.Store.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Messenger.Store
{
    public sealed class ProfileRepository : IRepository<Profile>
    {
        private readonly StoreContext _store;

        public ProfileRepository(StoreContext store) => _store = store;

        public async Task<Profile> Get(int id) =>
            await _store.Profiles.FirstOrDefaultAsync(p => p.Id == id);

        public async Task<bool> Add(Profile newProfile)
        {
            if (newProfile.Id != 0) { return false; }

            await _store.Profiles.AddAsync(newProfile);
            await _store.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(int id, Profile newState)
        {
            var profile = _store.Profiles.FirstOrDefault(p => p.Id == id);
            if (profile is null) { return false; }

            profile.CopyFrom(newState);
            await _store.SaveChangesAsync();

            return true;
        }

        public Task<IEnumerable<Profile>> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
