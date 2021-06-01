using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace MessengerApi.Models
{
    public class Store : DbContext
    {
        private string _connection;
        public DbSet<Message> Messages { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<User> Users { get; set; }

        public Store(IConfiguration config)
        {
            _connection = config.GetConnectionString("DefaultConnection");
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Chat>().HasData(
                new Chat[] {
                    new Chat { Id = 1, Name = "Public" },
                    new Chat { Id = 2, Name = "Private" },
                });

            modelBuilder.Entity<Message>().HasData(
                new Message[]
                {
                    new Message { Id = 1, ChatId = 1, MessageText = "aloha" , UserName = "Backender" },
                    new Message { Id = 2, ChatId = 1, MessageText = "blabla" , UserName = "Frontender" },
                    new Message { Id = 3, ChatId = 2, MessageText = "aloha" , UserName = "Backender" },
                });

            modelBuilder.Entity<Profile>().HasData(
                new Profile[]
                {
                    new Profile { Id = 1, Nickname = "User" },
                    new Profile { Id = 2, Nickname = "Backender" },
                });

            modelBuilder.Entity<User>().HasData(new User[]
                {
                    new User { Id = 1, Email = "login@mail.ru", Password = "qwerty", ProfileId = 1 },
                });
        }
    }
}
