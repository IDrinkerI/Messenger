using Messenger.Data;
using Messenger.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;


namespace Messenger.Api.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private ChatRepository _repository;

        public ChatController(ChatRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetChats()
        {
            var chats = await _repository.GetChats();
            var cleanedChats = chats.Select(chat => new { chat.Id, chat.Name });

            return new JsonResult(cleanedChats);
        }

        [HttpPut]
        public async Task<IActionResult> AddChat([FromBody] Chat chat)
        {
            if (chat is null)
                return new UnsupportedMediaTypeResult();

            var additionResult = await _repository.AddChat(chat);
            if (additionResult)
                return new OkResult();
            else
                return new BadRequestResult();
        }
    }
}
