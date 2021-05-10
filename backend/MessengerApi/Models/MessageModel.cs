using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MessengerApi.Models
{
    public sealed class MessageModel
    {
        public string UserName { get; set; }
        public string MessageText { get; set; }

        public MessageModel() { }

        public MessageModel(string userName, string messageText)
        {
            UserName = userName;
            MessageText = messageText;
        }
    }
}
