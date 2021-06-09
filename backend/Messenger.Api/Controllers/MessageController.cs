using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Messenger.Store.Models;
using Messenger.Store;


namespace Messenger.Api.Controllers
{
    [Controller]
    [Route("api/[controller]/{chatId?}")]
    public sealed class MessageController : ControllerBase
    {
        private readonly IRepository<Message> _repository;

        public MessageController(IRepository<Message> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetMessages(int chatId)
        {
            var messages = await (_repository as MessageRepository).GetMessages(chatId);
            var cleanedMessage = messages.Select(m => new { id = m.Id, userName = m.UserName, messageText = m.MessageText });

            return new JsonResult(cleanedMessage);
        }

        [HttpPut]
        public async Task<IActionResult> AddMessage([FromBody] Message message)
        {
            if (message is null)
                return new UnsupportedMediaTypeResult();

            var additionResult = await _repository.Add(message);

            if (additionResult)
                return new OkResult();
            else
                return new BadRequestResult();
        }
    }
}
