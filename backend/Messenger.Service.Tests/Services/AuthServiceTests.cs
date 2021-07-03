﻿using System.Threading.Tasks;
using System;
using Xunit;
using Moq;
using Messenger.DataAccess;
using Messenger.Data;
using Messenger.Model;


namespace Messenger.Service.Tests
{
    public class AuthServiceTests
    {
        [Fact]
        public async void CheckPassword_Null_ThrowArgumentNullException()
        {
            IAuthService authService = new AuthService(null, null, null);
            async Task testCode() => await authService.CheckPassword(null);

            await Assert.ThrowsAsync<ArgumentNullException>(testCode);
        }

        [Fact]
        public async void CheckPassword_WrongEmail_ReturnFalse()
        {
            var authInfo = new AuthInfoModel { Email = "wrongEmail@mail.com" };
            var userRepository = Mock.Of<IUserRepository<UserEntity>>(rep =>
                    rep.Get(It.IsAny<string>()) == Task.FromResult<UserEntity>(null));

            IAuthService authService = new AuthService(null, userRepository, null);
            var condition = await authService.CheckPassword(authInfo);

            Assert.False(condition);
        }

        [Fact]
        public async void CheckPassword_WrongPassword_ReturnFalse()
        {
            var signInData = new AuthInfoModel { Email = "TrueMail@mail.net", Password = "wrongPassword" };
            var authInfoId = 1;
            var authInfoRepository = Mock.Of<IRepository<AuthInfoEntity>>(rep =>
                    rep.Get(It.Is<int>(value => value.Equals(authInfoId)))
                    == Task.FromResult(new AuthInfoEntity { PasswordHash = "truePassword" }));
            var userRepository = Mock.Of<IUserRepository<UserEntity>>(rep =>
                    rep.Get(It.Is<string>(value => value.Equals(signInData.Email)))
                    == Task.FromResult(new UserEntity { AuthInfoId = authInfoId }));

            IAuthService authService = new AuthService(authInfoRepository, userRepository, null);
            var condition = await authService.CheckPassword(signInData);

            Assert.False(condition);
        }

        [Fact]
        public async void CheckPassword_TruePasswordAndEmail_ReturnTrue()
        {
            var signInData = new AuthInfoModel { Email = "TrueEmail@mail.net", Password = "truePassword" };
            var authInfoId = 1;
            var authInfoRepository = Mock.Of<IRepository<AuthInfoEntity>>(rep =>
                    rep.Get(It.Is<int>(value => value.Equals(authInfoId)))
                    == Task.FromResult(new AuthInfoEntity { PasswordHash = "truePassword" }));
            var userRepository = Mock.Of<IUserRepository<UserEntity>>(rep =>
                    rep.Get(It.Is<string>(value => value.Equals(signInData.Email)))
                    == Task.FromResult(new UserEntity { AuthInfoId = authInfoId, Email = signInData.Email }));

            IAuthService authService = new AuthService(authInfoRepository, userRepository, null);
            var condition = await authService.CheckPassword(signInData);

            Assert.True(condition);
        }

        [Fact]
        public async void Contains_ExistingUser_ReturnTrue()
        {
            var authInfo = new AuthInfoModel { Email = "someMail@mail.com" };
            var userRepository = Mock.Of<IUserRepository<UserEntity>>(rep =>
                    rep.Get(It.Is<string>(value => value.Equals(authInfo.Email)))
                    == Task.FromResult(new UserEntity()));

            IAuthService authService = new AuthService(null, userRepository, null);
            var condition = await authService.Contains(authInfo);

            Assert.True(condition);
        }

        [Fact]
        public async void Contains_NonExistingUser_ReturnFalse()
        {
            var userRepository = Mock.Of<IUserRepository<UserEntity>>(rep =>
                   rep.Get(It.IsAny<string>()) == Task.FromResult<UserEntity>(null));

            IAuthService authService = new AuthService(null, userRepository, null);
            var condition = await (authService).Contains(new AuthInfoModel());

            Assert.False(condition);
        }

        [Fact]
        public async void Contains_Null_ThrowArgumentNullException()
        {
            IAuthService authService = new AuthService(null, null, null);
            async Task testCode() => await (authService).Contains(null);

            await Assert.ThrowsAsync<ArgumentNullException>(testCode);
        }
    }
}
