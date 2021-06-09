namespace Messenger.Store.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string Nickname { get; set; }

        // TODO: rename method
        public void CopyFrom(Profile other)
        {
            Nickname = other.Nickname;
        }
    }
}
