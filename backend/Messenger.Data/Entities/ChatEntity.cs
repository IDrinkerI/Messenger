using System.Collections.Generic;


namespace Messenger.Data
{
    public class ChatEntity : BaseEntity
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }

        public List<MessageEntity> Messages { get; set; }
    }
}
