﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Model
{
    public class AuthInfoModel : BaseModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}