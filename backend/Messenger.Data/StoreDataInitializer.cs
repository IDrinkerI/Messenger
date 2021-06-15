using Messenger.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace Messenger.Data
{
    internal static class StoreDataInitializer
    {
        public static void InitializeData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MessageEntity>().HasData(
                    new MessageEntity
                    {
                        Id = 1,
                        Text = "Aloha",
                        ProfileId = 1,
                        ChatId = 1
                    }
                );

            modelBuilder.Entity<ChatEntity>().HasData(
                    new ChatEntity { Id = 1, Name = "Test" }
                );

            modelBuilder.Entity<ProfileEntity>().HasData(
                    new ProfileEntity { Id = 1, Nickname = "Developer" }
                );

            modelBuilder.Entity<AuthInfoEntity>().HasData(
                    new AuthInfoEntity() { Id = 1, PasswordHash = "qwerty" }
                );

            modelBuilder.Entity<UserEntity>().HasData(
                    new UserEntity
                    {
                        Id = 1,
                        Email = "login@mail.ru",
                        AuthInfoId = 1,
                        ProfileId = 1
                    }
                );
        }
    }
}
