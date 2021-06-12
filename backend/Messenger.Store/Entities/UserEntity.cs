using System.Collections.Generic;


namespace Messenger.Data.Entities
{
    public class UserEntity : BaseEntity, IUpdatableEntity<UserEntity>
    {
        public string Email { get; set; }
        public int ProfileId { get; set; }
        public ProfileEntity Profile { get; set; }
        public int AuthInfoId { get; set; }
        public AuthInfoEntity AuthInfo { get; set; }
        public HashSet<ChatEntity> Chats { get; set; }

        public void UpdateState(UserEntity newState)
        {
            Email = newState.Email;
        }
    }
}
