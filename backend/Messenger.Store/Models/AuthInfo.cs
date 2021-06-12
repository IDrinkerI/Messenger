using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Store.Models
{
    public class AuthInfo
    {
        public int Id { get; set; }
        public string PasswordHash { get; set; }
    }
}
