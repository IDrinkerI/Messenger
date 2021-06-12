using System.Collections.Generic;


namespace Messenger.Data.Entities
{
    public class ChatEntity : BaseEntity
    {
        public string Name { get; set; }

        public List<MessageEntity> Messages { get; set; }
    }
}
