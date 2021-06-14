﻿using Messenger.Data.Entities;
using Messenger.DataAccess;
using Messenger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Messenger.Service
{
    public class AuthService
    {
        private readonly IRepository<AuthInfoEntity> authInfoRepository;
        private readonly IUserRepository<UserEntity> userRepository;

        public AuthService(IRepository<AuthInfoEntity> authInfoRepository, IUserRepository<UserEntity> userRepository)
        {
            this.authInfoRepository = authInfoRepository;
            this.userRepository = userRepository;
        }

        async public Task<bool> CheckPassword(AuthInfoModel signinData)
        {
            var user = await userRepository.Get(signinData.Email);
            if (user is null) { return false; }

            var authInfo = await authInfoRepository.Get(user.AuthInfoId);
            var passwordHash = authInfo.PasswordHash;

            return passwordHash == signinData.Password;
        }

        async public Task AddUser(AuthInfoModel newUser)
        {
            var checkUser = await userRepository.Get(newUser.Email);
            if (checkUser is not null) { return; }

            var user = new UserEntity
            {
                Email = newUser.Email,
                AuthInfo = new AuthInfoEntity
                {
                    PasswordHash = newUser.Password
                },
                Profile = new ProfileEntity
                {
                    Nickname = newUser.Email
                }
            };

            await userRepository.Add(user);
        }

        async public Task<bool> Contains(AuthInfoModel newUser)
        {
            var user = await userRepository.Get(newUser.Email);

            if (user is null)
                return true;
            else
                return false;
        }
    }
}
