using Messenger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Messenger.Service
{
    public class MessageService
    {
        async public Task<IEnumerable<MessageModel>> GetMessages(int chatId)
        {
            throw new NotImplementedException();
        }

        async public Task AddMessage(MessageModel message)
        {
            throw new NotImplementedException();
        }
    }

}
