using System.Collections.Generic;


namespace Messenger.Store.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public HashSet<Message> Messages { get; set; }
    }
}
