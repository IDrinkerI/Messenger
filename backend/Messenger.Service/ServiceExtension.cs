﻿using Microsoft.Extensions.DependencyInjection;


namespace Messenger.Service
{
    public static class ServiceExtension
    {
        public static void AddMessengerServices(this IServiceCollection services)
        {
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IChatService, ChatService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
