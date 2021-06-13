﻿namespace Messenger.Data.Entities
{
    public class ProfileEntity : BaseEntity, IUpdatableEntity<ProfileEntity>
    {
        public string Nickname { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public void UpdateState(ProfileEntity newState)
        {
            Nickname = newState.Nickname;
            FirstName = newState.FirstName;
            LastName = newState.LastName;
        }
    }
}