using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MessengerApi.Models
{
    public sealed class Message
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string MessageText { get; set; }

        public Message() { }

        public Message(string userName, string messageText)
        {
            UserName = userName;
            MessageText = messageText;
        }
    }
}
