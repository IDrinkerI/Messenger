using System.Threading.Tasks;
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
        public async void CheckPassword_Null_ReturnFalse()
        {
            AuthInfoModel authInfo = null;

            var authService = new AuthService(null, null, null);
            var condition   = await authService.CheckPassword(authInfo);

            Assert.False(condition);
        }

        [Fact]
        public async void CheckPassword_WrongEmail_ReturnFalse()
        {
            var authInfo = new AuthInfoModel { Email = "SomeWrong@mail.net" };
            Mock<IUserRepository<UserEntity>> mockUserRepository = new();

            mockUserRepository.Setup(rep => rep.Get(It.IsAny<string>()))
                .Returns(Task.FromResult<UserEntity>(null));

            var authService = new AuthService(null, mockUserRepository.Object, null);
            var condition   = await authService.CheckPassword(authInfo);

            mockUserRepository.VerifyAll();
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
                    It.Is<int>(value => value.Equals(authInfoId)))
                )
                .Returns(Task.FromResult(new AuthInfoEntity { PasswordHash = "truePassword" }));
            mockUserRepository.Setup(rep => rep.Get(

                    It.Is<string>(value => value.Equals(signInData.Email)))
                )
                .Returns(Task.FromResult(new UserEntity { AuthInfoId = authInfoId }));


            var authService = new AuthService(
                mockAuthInfoRepository.Object,
                mockUserRepository.Object,
                null);
            var condition = await authService.CheckPassword(signInData);

            mockAuthInfoRepository.VerifyAll();
            mockUserRepository.VerifyAll();
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
                    It.Is<int>(value => value.Equals(authInfoId)))
                )
                .Returns(Task.FromResult(new AuthInfoEntity { PasswordHash = "truePassword" }));

            mockUserRepository.Setup(rep => rep.Get(
                    It.Is<string>(value => value.Equals(signInData.Email)))
                )
                .Returns(Task.FromResult(new UserEntity { AuthInfoId = authInfoId, Email = signInData.Email }));


            var authService = new AuthService(
                mockAuthInfoRepository.Object,
                mockUserRepository.Object,
                null);
            var condition = await authService.CheckPassword(signInData);

            mockAuthInfoRepository.VerifyAll();
            mockUserRepository.VerifyAll();
            Assert.True(condition);
        }
    }

}