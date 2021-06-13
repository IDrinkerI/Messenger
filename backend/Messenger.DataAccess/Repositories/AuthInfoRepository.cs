using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.Data;
using Messenger.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace Messenger.DataAccess
{
    public class AuthInfoRepository : IRepository<AuthInfoEntity>
    {
        private readonly StoreContext store;

        public AuthInfoRepository(StoreContext store)
        {
            this.store = store;
        }

        async void IRepository<AuthInfoEntity>.Add(AuthInfoEntity item)
        {
            if (item is null) { return; }

            await store.AuthInfos.AddAsync(item);
            await store.SaveChangesAsync();
        }

        Task<AuthInfoEntity> IRepository<AuthInfoEntity>.Get(int id)
        {
            var authInfo = store.AuthInfos
                .FirstOrDefaultAsync(i => i.Id == id);

            return authInfo;
        }

        Task<IEnumerable<AuthInfoEntity>> IRepository<AuthInfoEntity>.GetAll()
        {
            throw new NotImplementedException();
        }

        async void IRepository<AuthInfoEntity>.Update(int id, AuthInfoEntity newState)
        {
            var authInfo = await store.AuthInfos
                .FirstOrDefaultAsync(i => i.Id == id);

            if (authInfo is null) { return; }

            authInfo.UpdateState(newState);
            await store.SaveChangesAsync();
        }
    }
}
