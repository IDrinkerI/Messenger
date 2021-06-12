namespace Messenger.Data.Entities
{
    public class ProfileEntity : BaseEntity
    {
        public string Nickname { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
