namespace Messenger.Data.Entities
{
    public class ProfileEntity
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // TODO: rename method
        public void CopyFrom(ProfileEntity other)
        {
            Nickname = other.Nickname;
            FirstName = other.FirstName;
            LastName = other.LastName;
        }
    }
}
