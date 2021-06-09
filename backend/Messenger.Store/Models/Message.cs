namespace Messenger.Store.Models
{
    public sealed class Message
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string MessageText { get; set; }
        public Chat Chat { get; set; }
        public int ChatId { get; set; }
    }
}
