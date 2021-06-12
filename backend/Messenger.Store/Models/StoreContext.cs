using Messenger.Store.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Messenger.Store.Models
{
    public sealed class StoreContext : DbContext
    {
        private readonly string connectionString;
        public DbSet<Message> Messages { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<AuthInfo> AuthInfos { get; set; }

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

            modelBuilder.Entity<Chat>().HasData(
                new Chat[] {
                    new Chat { Id = 1, Name = "Public" },
                    new Chat { Id = 2, Name = "Private" },
                });

            modelBuilder.Entity<Message>().HasData(
                new Message[]
                {
                    new Message { Id = 1, ChatId = 1, Text = "aloha" , ProfileId = 2 },
                    new Message { Id = 1, ChatId = 1, Text = "aloha" , ProfileId = 1 },
                    new Message { Id = 2, ChatId = 1, Text = "blabla" , ProfileId = 2 },
                    new Message { Id = 3, ChatId = 2, Text = "aloha" , ProfileId = 3 },
                });

            modelBuilder.Entity<Profile>().HasData(
                new Profile[]
                {
                    new Profile { Id = 1, Nickname = "User" },
                    new Profile { Id = 2, Nickname = "Backender" },
                    new Profile { Id = 3, Nickname = "Developer"},
                });

            modelBuilder.Entity<User>().HasData(new User[]
                {
                    new User { Id = 1, Email = "login@mail.ru", Password = "qwerty", ProfileId = 1 },
                });
        }
    }
}
