using Microsoft.Extensions.DependencyInjection;


namespace Messenger.Service
{
    public static class ServiceExtension
    {
        public static void AddMessengerServices(this IServiceCollection services)
        {
            services.AddScoped<MessageService>();
            services.AddScoped<ChatService>();
            services.AddScoped<ProfileService>();
            services.AddScoped<AuthService>();
        }
    }
}
