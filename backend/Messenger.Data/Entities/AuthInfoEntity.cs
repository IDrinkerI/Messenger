using System.Threading.Tasks;


namespace Messenger.Data
{
    public class AuthInfoEntity : BaseEntity, IUpdatableEntity<AuthInfoEntity>
    {
        public string PasswordHash { get; set; }

        public Task UpdateState(AuthInfoEntity newState)
        {
            PasswordHash = newState.PasswordHash;
            return Task.CompletedTask;
        }
    }
}
