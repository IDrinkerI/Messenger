using System.Threading.Tasks;


namespace Messenger.Data
{
    public class SessionEntity : BaseEntity, IUpdatableEntity<SessionEntity>
    {
        public string Token { get; set; }
        public System.DateTime KillingTime { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }

        public Task UpdateState(SessionEntity newState)
        {
            KillingTime = newState.KillingTime;
            return Task.CompletedTask;
        }
    }
}
