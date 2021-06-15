using Messenger.Data.Entities;
using Messenger.DataAccess;
using Messenger.Mapper;
using Messenger.Model;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Messenger.Service
{
    public sealed class MessageService
    {
        private readonly IMessageRepository<MessageEntity> messageRepository;

        public MessageService(IMessageRepository<MessageEntity> messageRepository) =>
            this.messageRepository = messageRepository;

        public async Task<IEnumerable<MessageModel>> GetMessages(int chatId)
        {
            var entities = await messageRepository.GetAll(chatId);
            var messages = new List<MessageModel>();

            foreach (var entity in entities)
                messages.Add(entity.ToModel());

            return messages;
        }

        public async Task AddMessage(MessageModel message)
        {
            var messageEntity = message.ToEntity();
            await messageRepository.Add(messageEntity);
        }
    }
}
