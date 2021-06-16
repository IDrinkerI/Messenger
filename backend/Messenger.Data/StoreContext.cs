using Messenger.Data.Configuration;
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
            optionsBuilder.UseSqlServer(connectionString);
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

            // TODO: delete before release
            modelBuilder.InitializeData();
        }
    }
}
