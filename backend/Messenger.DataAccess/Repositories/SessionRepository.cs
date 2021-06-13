using Messenger.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Messenger.Data;


namespace Messenger.DataAccess
{
    public sealed class SessionRepository : IRepository<SessionEntity>
    {
        private readonly StoreContext store;

        public SessionRepository(StoreContext store)
        {
            this.store = store;
        }

        async void IRepository<SessionEntity>.Add(SessionEntity item)
        {
            if (item is null) { return; }

            await store.Sessions.AddAsync(item);
            await store.SaveChangesAsync();
        }

        async Task<SessionEntity> IRepository<SessionEntity>.Get(int id)
        {
            var session = await store.Sessions
                .FirstOrDefaultAsync(s => s.Id == id);

            return session;
        }

        Task<IEnumerable<SessionEntity>> IRepository<SessionEntity>.GetAll()
        {
            throw new NotImplementedException();
        }

      async  void IRepository<SessionEntity>.Update(int id, SessionEntity newState)
        {
            var session = await store.Sessions
                .FirstOrDefaultAsync(s => s.Id == id);

            if(session is null) { return; }

            session.UpdateState(newState);
            await store.SaveChangesAsync();
        }
    }
}
