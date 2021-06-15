using Messenger.Model;
using Messenger.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace Messenger.Api.Controllers
{
    public sealed class MessageController : MessengerApiController
    {
        private readonly MessageService messageService;

        public MessageController(MessageService messageService) =>
            this.messageService = messageService;

        /// <summary>
        /// Return all messages by chat id
        /// </summary>
        /// <param name="chatId"></param>
        /// <returns></returns>
        [HttpGet("{chatId?}")]
        public async Task<IActionResult> GetMessages(int chatId)
        {
            var messages = await messageService.GetMessages(chatId);
            return new JsonResult(messages);
        }

        [HttpPut]
        public async Task<IActionResult> AddMessage([FromBody] MessageModel message)
        {
            if (message is null)
                return new UnsupportedMediaTypeResult();

            await messageService.AddMessage(message);
            return new OkResult();
        }
    }
}
