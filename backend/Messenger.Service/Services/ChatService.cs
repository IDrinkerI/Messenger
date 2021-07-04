using Messenger.Data;
using Messenger.DataAccess;
using Messenger.Mapper;
using Messenger.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Messenger.Service
{
    public sealed class ChatService : IChatService
    {
        private readonly IChatRepository<ChatEntity> repository;
        private readonly IAuthService authService;

        public ChatService(IChatRepository<ChatEntity> repository, IAuthService authService)
        {
            this.repository  = repository;
            this.authService = authService;
        }

        async Task<bool> IChatService.AddChat(ChatModel chat)
        {
            if (chat is null)
                throw new ArgumentNullException();

            if (string.IsNullOrWhiteSpace(chat.Name))
                throw new ArgumentException("Name should not be empty or contain only spaces!");

            var entity = chat.ToEntity();
            await repository.Add(entity);
            return true;
        }

        async Task<IEnumerable<ChatModel>> IChatService.GetChats()
        {
            var chatid = authService.CurrentUserId;
            var chatEntities = await repository.GetChats(chatid);

            var chats = new List<ChatModel>();
            foreach (var entity in chatEntities)
                chats.Add(entity.ToModel());

            return chats;
        }
    }
}
