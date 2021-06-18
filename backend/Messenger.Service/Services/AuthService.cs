using Messenger.Data;
using Messenger.DataAccess;
using Messenger.Model;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;


namespace Messenger.Service
{
    public sealed class AuthService : IAuthService
    {
        private readonly IRepository<AuthInfoEntity> authInfoRepository;
        private readonly IUserRepository<UserEntity> userRepository;
        private readonly IHttpContextAccessor contextAccessor;

        public int CurrentUserId
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

        public AuthService(IRepository<AuthInfoEntity> authInfoRepository,
                           IUserRepository<UserEntity> userRepository,
                           IHttpContextAccessor contextAccessor)
        {
            this.authInfoRepository = authInfoRepository;
            this.userRepository = userRepository;
            this.contextAccessor = contextAccessor;
        }

        public async Task<bool> CheckPassword(AuthInfoModel signinData)
        {
            if(signinData is null) { return false; }

            var user = await userRepository.Get(signinData.Email);
            if (user is null) { return false; }

            var authInfo     = await authInfoRepository.Get(user.AuthInfoId);
            var passwordHash = authInfo.PasswordHash;

            return passwordHash == signinData.Password;
        }

        public async Task AddUser(AuthInfoModel newUser)
        {
            var checkUser = await userRepository.Get(newUser.Email);
            if (checkUser is not null) { return; }

            var user = new UserEntity
            {
                Email    = newUser.Email,
                AuthInfo = new AuthInfoEntity { PasswordHash = newUser.Password },
                Profile  = new ProfileEntity { Nickname = newUser.Email }
            };

            await userRepository.Add(user);
        }

        public async Task<bool> Contains(AuthInfoModel newUser)
        {
            var user = await userRepository.Get(newUser.Email);

            if (user is null)
                return true;
            else
                return false;
        }
    }
}
