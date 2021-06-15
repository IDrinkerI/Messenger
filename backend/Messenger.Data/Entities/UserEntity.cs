using System.Collections.Generic;
using System.Threading.Tasks;


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

        public Task UpdateState(UserEntity newState)
        {
            Email = newState.Email;
            return Task.CompletedTask;
        }
    }
}
