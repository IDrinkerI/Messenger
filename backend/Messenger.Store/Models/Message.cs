namespace Messenger.Data.Models
{
    public sealed class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
        public int ChatId { get; set; }
        public Chat Chat { get; set; }
    }
}
