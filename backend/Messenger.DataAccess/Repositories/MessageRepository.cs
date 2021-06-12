using Messenger.Data;
using Messenger.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Messenger.DataAccess
{
    public sealed class MessageRepository : IRepository<MessageEntity>
    {
        private readonly StoreContext store;

        public MessageRepository(StoreContext store)
        {
            this.store = store;
        }

        async void IRepository<MessageEntity>.Add(MessageEntity item)
        {
            if (item is null) { return; }

            await store.Messages.AddAsync(item);
            await store.SaveChangesAsync();
        }

        Task<MessageEntity> IRepository<MessageEntity>.Get(int id)
        {
            var message = store.Messages
                .FirstOrDefaultAsync(m => m.Id == id);

            return message;
        }

        Task<IEnumerable<MessageEntity>> IRepository<MessageEntity>.GetAll()
        {
            throw new System.NotImplementedException();
        }

        async void IRepository<MessageEntity>.Update(int id, MessageEntity newState)
        {
            var message = await store.Messages
                .FirstOrDefaultAsync(m => m.Id == id);

            if (message is null) { return; }

            message = newState;
            await store.SaveChangesAsync();
         }
    }
}
