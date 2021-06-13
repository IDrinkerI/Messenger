﻿using Messenger.Data;
using Messenger.Data.Entities;
using Microsoft.Extensions.DependencyInjection;


namespace Messenger.DataAccess
{
    public static class MessengerDataAccessExtension
    {
        public static void AddMessengerDataRepositories(this IServiceCollection services)
        {
            services.AddDbContext<StoreContext>();
            services.AddScoped<IRepository<MessageEntity>, MessageRepository>();
            services.AddScoped<IRepository<ChatEntity>, ChatRepository>();
            services.AddScoped<IRepository<ProfileEntity>, ProfileRepository>();
            services.AddScoped<IRepository<UserEntity>, UserRepository>();
            services.AddScoped<IRepository<AuthInfoEntity>, AuthInfoRepository>();
            services.AddScoped<IRepository<SessionEntity>, SessionRepository>();
        }
    }
}