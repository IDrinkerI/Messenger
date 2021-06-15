using System.Threading.Tasks;


namespace Messenger.Data.Entities
{
    public sealed class MessageEntity : BaseEntity, IUpdatableEntity<MessageEntity>
    {
        public string Text { get; set; }
        public int ProfileId { get; set; }
        public ProfileEntity Profile { get; set; }
        public int ChatId { get; set; }
        public ChatEntity Chat { get; set; }

        public Task UpdateState(MessageEntity newState)
        {
            Text = newState.Text;
            return Task.CompletedTask;
        }
    }
}
