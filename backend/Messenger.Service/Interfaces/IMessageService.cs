using Messenger.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Messenger.Service
{
    public interface IMessageService
    {
        Task AddMessage(MessageModel message);
        Task<IEnumerable<MessageModel>> GetMessages(int chatId);
    }
}