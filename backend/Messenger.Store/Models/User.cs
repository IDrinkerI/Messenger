using System.Collections.Generic;


namespace Messenger.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
        public int AuthInfoId { get; set; }
        public AuthInfo AuthInfo { get; set; }
        public HashSet<Chat> Chats { get; set; }
    }
}
