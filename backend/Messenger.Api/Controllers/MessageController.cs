using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Messenger.Data.Models;
using Messenger.Data;


namespace Messenger.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/{chatId?}")]
    public sealed class MessageController : ControllerBase
    {
        private readonly MessageRepository repository;

        public MessageController(MessageRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Return all messages by chat id
        /// </summary>
        /// <param name="chatId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetMessages(int chatId)
        {
            var messages = await repository.GetMessages(chatId);
            var cleanedMessage = messages.Select(m => new { id = m.Id, userName = m.Profile.Nickname, messageText = m.Text });

            return new JsonResult(cleanedMessage);
        }

        [HttpPut]
        public async Task<IActionResult> AddMessage([FromBody] Message message)
        {
            if (message is null)
                return new UnsupportedMediaTypeResult();

            var additionResult = await repository.AddMessage(message, 1);

            if (additionResult)
                return new OkResult();
            else
                return new BadRequestResult();
        }
    }
}
