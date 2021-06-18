using Messenger.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Messenger.Service
{
    public interface IChatService
    {
        Task AddChat(ChatModel chat);
        Task<IEnumerable<ChatModel>> GetChats();
    }
}