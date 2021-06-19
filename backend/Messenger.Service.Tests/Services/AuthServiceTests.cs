using System.Threading.Tasks;
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
            AuthInfoModel authInfo = null;

            var authService     = new AuthService(null, null, null);
            Func<Task> testCode = async () => await authService.CheckPassword(authInfo);

            await Assert.ThrowsAsync<ArgumentNullException>(testCode);
        }

        [Fact]
        public async void CheckPassword_WrongEmail_ReturnFalse()
        {
            var authInfo = new AuthInfoModel();
            var userRepository = Mock.Of<IUserRepository<UserEntity>>(rep => 
                    rep.Get(It.IsAny<string>()) == Task.FromResult<UserEntity>(null));

            var authService = new AuthService(null, userRepository, null);
            var condition   = await authService.CheckPassword(authInfo);

            Assert.False(condition);
        }

        [Fact]
        public async void CheckPassword_WrongPassword_ReturnFalse()
        {
            var signInData = new AuthInfoModel { Email = "TrueMail@mail.net", Password = "wrongPassword" };
            Mock<IRepository<AuthInfoEntity>> mockAuthInfoRepository = new();
            Mock<IUserRepository<UserEntity>> mockUserRepository = new();
            var authInfoId = 11;

            mockAuthInfoRepository.Setup(rep => rep.Get(
                    It.Is<int>(value => value.Equals(authInfoId))))
                .Returns(Task.FromResult(new AuthInfoEntity { PasswordHash = "truePassword" }));
            mockUserRepository.Setup(rep => rep.Get(

                    It.Is<string>(value => value.Equals(signInData.Email))))
                .Returns(Task.FromResult(new UserEntity { AuthInfoId = authInfoId }));


            var authService = new AuthService(
                mockAuthInfoRepository.Object,
                mockUserRepository.Object,
                null);
            var condition = await authService.CheckPassword(signInData);

            mockAuthInfoRepository.Verify();
            mockUserRepository.Verify();
            Assert.False(condition);
        }

        [Fact]
        public async void CheckPassword_TruePasswordAndEmail_ReturnTrue()
        {
            var signInData = new AuthInfoModel { Email = "TrueEmail@mail.net", Password = "truePassword" };
            Mock<IRepository<AuthInfoEntity>> mockAuthInfoRepository = new();
            Mock<IUserRepository<UserEntity>> mockUserRepository = new();

            var authInfoId = 13;
            mockAuthInfoRepository.Setup(rep => rep.Get(
                    It.Is<int>(value => value.Equals(authInfoId))))
                .Returns(Task.FromResult(new AuthInfoEntity { PasswordHash = "truePassword" }));

            mockUserRepository.Setup(rep => rep.Get(
                    It.Is<string>(value => value.Equals(signInData.Email))))
                .Returns(Task.FromResult(new UserEntity { AuthInfoId = authInfoId, Email = signInData.Email }));


            var authService = new AuthService(
                mockAuthInfoRepository.Object,
                mockUserRepository.Object,
                null);
            var condition = await authService.CheckPassword(signInData);

            mockAuthInfoRepository.Verify();
            mockUserRepository.Verify();
            Assert.True(condition);
        }

        [Fact]
        public async void Contains_ExistingUser_ReturnTrue()
        {
            var userRepository = Mock.Of<IUserRepository<UserEntity>>(rep => 
                    rep.Get(It.IsAny<string>()) == Task.FromResult(new UserEntity()));

            var authService = new AuthService(null, userRepository, null);
            var condition   = await authService.Contains(new AuthInfoModel());

            Assert.True(condition);
        }

        [Fact]
        public async void Contains_NonExistingUser_ReturnFalse()
        {
            var userRepository = Mock.Of<IUserRepository<UserEntity>>(rep =>
                   rep.Get(It.IsAny<string>()) == Task.FromResult<UserEntity>(null));

            var authService = new AuthService(null, userRepository, null);
            var condition   = await authService.Contains(new AuthInfoModel());

            Assert.False(condition);
        }
    }
}
