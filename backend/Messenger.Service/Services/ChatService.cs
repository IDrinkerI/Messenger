using Messenger.Data;
using Messenger.DataAccess;
using Messenger.Mapper;
using Messenger.Model;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Messenger.Service
{
    public sealed class ChatService : IChatService
    {
        private readonly IRepository<ChatEntity> repository;

        public ChatService(IRepository<ChatEntity> repository) => this.repository = repository;

        async Task<IEnumerable<ChatModel>> IChatService.GetChats()
        {
            var chatEntities = await repository.GetAll();
            var chats = new List<ChatModel>();

            foreach (var entity in chatEntities)
                chats.Add(entity.ToModel());

            return chats;
        }

        async Task<bool> IChatService.AddChat(ChatModel chat)
        {
            var entity = chat.ToEntity();
            await repository.Add(entity);
            return true;
        }
    }
}
