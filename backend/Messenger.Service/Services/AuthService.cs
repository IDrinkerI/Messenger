﻿using Messenger.Data;
using Messenger.DataAccess;
using Messenger.Model;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;


namespace Messenger.Service
{
    public sealed class AuthService : IAuthService
    {
        private readonly IRepository<AuthInfoEntity> authInfoRepository;
        private readonly IUserRepository<UserEntity> userRepository;
        private readonly IHttpContextAccessor contextAccessor;

        public AuthService(IRepository<AuthInfoEntity> authInfoRepository,
                           IUserRepository<UserEntity> userRepository,
                           IHttpContextAccessor contextAccessor)
        {
            this.authInfoRepository = authInfoRepository;
            this.userRepository = userRepository;
            this.contextAccessor = contextAccessor;
        }

        int IAuthService.CurrentUserId
        {
            get
            {
                var user  = contextAccessor.HttpContext.User;
                var claim = user.FindFirst(c => c.Type == "Id");
                if (claim is null) { return 0; }

                var id = int.Parse(claim.Value);
                return id;
            }
        }

        async Task<bool> IAuthService.AddUser(AuthInfoModel newUser)
        {
            if (newUser is null)
                throw new ArgumentNullException();

            if (string.IsNullOrWhiteSpace(newUser.Email))
                throw new ArgumentException("The email address should not be empty or contain only spaces!");

            if (string.IsNullOrWhiteSpace(newUser.Password))
                throw new ArgumentException("The Password address should not be empty or contain only spaces!");

            var checkUser = await userRepository.Get(newUser.Email);
            if (checkUser is not null)
                return false;

            var user = new UserEntity
            {
                Email    = newUser.Email,
                AuthInfo = new AuthInfoEntity { PasswordHash = newUser.Password },
                Profile  = new ProfileEntity { Nickname = newUser.Email }
            };

            await userRepository.Add(user);
            return true;
        }

        async Task<bool> IAuthService.CheckPassword(AuthInfoModel signinData)
        {
            if (signinData is null)
                throw new ArgumentNullException();

            var user = await userRepository.Get(signinData.Email);
            if (user is null) { return false; }

            var authInfo = await authInfoRepository.Get(user.AuthInfoId);
            if (authInfo is null)
                throw new ApplicationException("AuthInfo is null. Каждый user должен иметь authInfo");

            return authInfo.PasswordHash == signinData.Password;
        }

        async Task<bool> IAuthService.Contains(AuthInfoModel newUser)
        {
            if (newUser is null)
                throw new ArgumentNullException();

            var user = await userRepository.Get(newUser.Email);

            if (user is not null)
                return true;
            else
                return false;
        }
    }
}
