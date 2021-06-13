using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Messenger.Service;
using Messenger.Model;


namespace Messenger.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/{chatId?}")]
    public sealed class MessageController : ControllerBase
    {
        private readonly MessageService messageService;

        public MessageController(MessageService messageService)
        {
            this.messageService = messageService;
        }

        /// <summary>
        /// Return all messages by chat id
        /// </summary>
        /// <param name="chatId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetMessages(int chatId)
        {
            var messages = await messageService.GetMessages(chatId);
            var cleanedMessage = messages.Select(m => new { id = m.Id, userName = m.Nickname, messageText = m.Text });

            return new JsonResult(cleanedMessage);
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
