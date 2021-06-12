namespace Messenger.Store.Models
{
    public class Session
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public System.DateTime KillingTime { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
