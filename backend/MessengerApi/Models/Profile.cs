using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessengerApi.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string Nickname { get; set; }

        // TODO: rename method
        public void CopyFrom(Profile other)
        {
            Nickname = other.Nickname;
        }
    }
}
