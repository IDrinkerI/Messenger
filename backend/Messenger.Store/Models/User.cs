namespace Messenger.Store.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
        public AuthInfo AuthInfo { get; set; }
    }
}
