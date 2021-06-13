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
        async public Task<bool> CheckPassword(AuthInfoModel signinData)
        {
            throw new NotImplementedException();
        }

        async public Task AddUser(AuthInfoModel newUser)
        {
            throw new NotImplementedException();
        }

        async public Task<bool> Contains(AuthInfoModel newUser)
        {
            throw new NotImplementedException();
        }
    }
}
