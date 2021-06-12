﻿namespace Messenger.Data.Entities
{
    public sealed class MessageEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int ProfileId { get; set; }
        public ProfileEntity Profile { get; set; }
        public int ChatId { get; set; }
        public ChatEntity Chat { get; set; }
    }
}
