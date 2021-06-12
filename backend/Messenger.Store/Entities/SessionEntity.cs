namespace Messenger.Data.Entities
{
    public class SessionEntity : BaseEntity
    {
        public string Token { get; set; }
        public System.DateTime KillingTime { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }
    }
}
