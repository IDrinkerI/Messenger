using System.Collections.Generic;


namespace Messenger.Data.Entities
{
    public class ChatEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<MessageEntity> Messages { get; set; }
    }
}
