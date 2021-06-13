namespace Messenger.Data.Entities
{
    public class AuthInfoEntity : BaseEntity, IUpdatableEntity<AuthInfoEntity>
    {
        public string PasswordHash { get; set; }

        public void UpdateState(AuthInfoEntity newState)
        {
            PasswordHash = newState.PasswordHash;
        }
    }
}
