using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessengerApi.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Chat() { }

        public Chat(string name)
        {
            Name = name;
        }
    }
}
