using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace MessengerApi.Models
{
    public class Store : DbContext
    {
        public DbSet<Message> Messages { get; set; }
        public DbSet<Chat> Chats { get; set; }
        private string _connection;

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
    }
}