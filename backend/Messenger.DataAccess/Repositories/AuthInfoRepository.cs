using Messenger.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Messenger.DataAccess
{
    public sealed class AuthInfoRepository : IRepository<AuthInfoEntity>
    {
        private readonly StoreContext store;

        public AuthInfoRepository(StoreContext store) => this.store = store;

        async Task IRepository<AuthInfoEntity>.Add(AuthInfoEntity item)
        {
            if (item is null) { return; }

            await store.AuthInfos.AddAsync(item);
            await store.SaveChangesAsync();
        }

        async Task<AuthInfoEntity> IRepository<AuthInfoEntity>.Get(int id)
        {
            var authInfo = await store.AuthInfos
                .FirstOrDefaultAsync(i => i.Id == id);

            return authInfo;
        }

        Task<IEnumerable<AuthInfoEntity>> IRepository<AuthInfoEntity>.GetAll()
        {
            throw new NotImplementedException();
        }

        async Task IRepository<AuthInfoEntity>.Update(int id, AuthInfoEntity newState)
        {
            var authInfo = await store.AuthInfos
                .FirstOrDefaultAsync(i => i.Id == id);

            if (authInfo is null) { return; }

            await authInfo.UpdateState(newState);
            await store.SaveChangesAsync();
        }
    }
}
