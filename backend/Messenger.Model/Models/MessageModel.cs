namespace Messenger.Model
{
    public sealed class MessageModel : BaseModel
    {
        public string Text { get; set; }
        public string Nickname { get; set; }
        public int ProfileId { get; set; }
        public int ChatId { get; set; }
    }
}
