using System.Collections.Generic;


namespace Messenger.Data.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int ProfileId { get; set; }
        public ProfileEntity Profile { get; set; }
        public int AuthInfoId { get; set; }
        public AuthInfoEntity AuthInfo { get; set; }
        public HashSet<ChatEntity> Chats { get; set; }
    }
}
