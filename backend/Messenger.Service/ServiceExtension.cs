using Microsoft.Extensions.DependencyInjection;


namespace Messenger.Service
{
    public static class ServiceExtension
    {
        public static void AddMessengerServices(this IServiceCollection services)
        {
            services.AddSingleton<MessageService>();
        }
    }
}
