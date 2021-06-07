using Messenger.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Messenger.Data
{
    public sealed class MessageRepository
    {
        private Store _store;

        public MessageRepository(Store store)
        {
            _store = store;
        }

        public async Task<bool> AddMessage(Message message)
        {
            if (message is null ||
                message.UserName is null)
            {
                return false;
            }

            var chat = await _store.Chats.FirstOrDefaultAsync(chat => chat.Id == message.ChatId);
            // TODO: alter this trash
            if (chat is null) { return false; }

            await _store.Messages.AddAsync(message);
            await _store.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Message>> GetMessages(int chatId)
        {
            var messages = await _store.Messages.Where(m => m.ChatId == chatId)
                .ToArrayAsync();

            return messages;
        }
    }
}
