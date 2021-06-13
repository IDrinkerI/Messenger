using Messenger.Data.Configuration;
using Messenger.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Messenger.Data
{
    public sealed class StoreContext : DbContext
    {
        private readonly string connectionString;
        public DbSet<MessageEntity> Messages { get; set; }
        public DbSet<ChatEntity> Chats { get; set; }
        public DbSet<ProfileEntity> Profiles { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<SessionEntity> Sessions { get; set; }
        public DbSet<AuthInfoEntity> AuthInfos { get; set; }

        public StoreContext(IConfiguration config)
        {
            connectionString = config.GetConnectionString("DefaultConnection");
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString, o =>
                // TODO: get asembly name from config
                o.MigrationsAssembly("Messenger.Api")
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new MessageEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ChatEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProfileEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SessionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AuthInfoEntityConfiguration());

            modelBuilder.Entity<MessageEntity>().HasData(
                new MessageEntity[]
                    {
                        new MessageEntity { Id = 1, Text = "aloha" , ProfileId = 2, ChatId = 1 },
                        new MessageEntity { Id = 2, Text = "aloha" , ProfileId = 1, ChatId = 1},
                        new MessageEntity { Id = 3, Text = "blabla" , ProfileId = 2, ChatId = 2},
                        new MessageEntity { Id = 4, Text = "aloha" , ProfileId = 3, ChatId = 2},
                    }
                );

            modelBuilder.Entity<ChatEntity>().HasData(
                new ChatEntity[] {
                    new ChatEntity { Id = 1, Name = "Public" },
                    new ChatEntity { Id = 2, Name = "Private" },
                });

            modelBuilder.Entity<ProfileEntity>().HasData(
                new ProfileEntity[]
                {
                    new ProfileEntity { Id = 1, Nickname = "User" },
                    new ProfileEntity { Id = 2, Nickname = "Backender" },
                    new ProfileEntity { Id = 3, Nickname = "Developer"},
                });

            modelBuilder.Entity<AuthInfoEntity>().HasData(new AuthInfoEntity() { Id = 1, PasswordHash = "qwerty" });

            modelBuilder.Entity<UserEntity>().HasData(new UserEntity[]
                {
                    new UserEntity {
                        Id = 1,
                        Email = "login@mail.ru",
                        AuthInfoId = 1,
                        ProfileId = 1
                    },
                });
        }
    }
}
