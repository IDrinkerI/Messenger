using Messenger.Data.Entities;
using Messenger.Model;


namespace Messenger.Mapper
{
    public static class ChatMapper
    {
        public static ChatEntity ToEntity(this ChatModel chatModel)
        {
            var entity = new ChatEntity
            {
                Name = chatModel.Name,
                Id   = chatModel.Id,
            };

            return entity;
        }

        public static ChatModel ToModel(this ChatEntity chatEntity)
        {
            var model = new ChatModel
            {
                Name = chatEntity.Name,
                Id   = chatEntity.Id,
            };

            return model;
        }
    }
}
