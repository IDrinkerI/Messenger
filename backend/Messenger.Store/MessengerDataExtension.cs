using Messenger.Store.Models;
using Microsoft.Extensions.DependencyInjection;


namespace Messenger.Store
{
    public static class MessengerDataExtension
    {
        public static void AddMessengerDataRepositories(this IServiceCollection services)
        {
            services.AddDbContext<StoreContext>();
            services.AddScoped<MessageRepository>();
            services.AddScoped<IRepository<Chat>, ChatRepository>();
            services.AddScoped<IRepository<Profile>, ProfileRepository>();
            services.AddScoped<UserRepository>();
        }
    }
}
