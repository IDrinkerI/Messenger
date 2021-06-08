using Messenger.Data.Models;
using Microsoft.Extensions.DependencyInjection;


namespace Messenger.Data
{
    public static class MessengerDataExtension
    {
        public static void AddMessengerDataRepositories(this IServiceCollection services)
        {
            services.AddDbContext<StoreContext>();
            services.AddScoped<MessageRepository>();
            services.AddScoped<ChatRepository>();
            services.AddScoped<ProfileRepository>();
            services.AddScoped<UserRepository>();
        }
    }
}
