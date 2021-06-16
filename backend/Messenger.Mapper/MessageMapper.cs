using Messenger.Data.Entities;
using Messenger.Model;


namespace Messenger.Mapper
{
    public static class MessageMapper
    {
        public static MessageEntity ToEntity(this MessageModel messageModel)
        {
            var entity = new MessageEntity
            {
                Id        = messageModel.Id,
                Text      = messageModel.Text,
                ChatId    = messageModel.ChatId,
                ProfileId = messageModel.ProfileId,
            };

            return entity;
        }

        public static MessageModel ToModel(this MessageEntity messageEntity)
        {
            var model = new MessageModel
            {
                Id        = messageEntity.Id,
                Text      = messageEntity.Text,
                ChatId    = messageEntity.ChatId,
                ProfileId = messageEntity.ProfileId,
                Nickname  = messageEntity.Profile?.Nickname,
            };

            return model;
        }
    }
}
