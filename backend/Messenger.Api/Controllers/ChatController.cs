using Messenger.Store;
using Messenger.Store.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;


namespace Messenger.Api.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    internal sealed class ChatController : ControllerBase
    {
        private readonly ChatRepository repository;

        public ChatController(ChatRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetChats()
        {
            var chats = await repository.GetChats();
            var cleanedChats = chats.Select(chat => new { chat.Id, chat.Name });

            return new JsonResult(cleanedChats);
        }

        [HttpPut]
        public async Task<IActionResult> AddChat([FromBody] Chat chat)
        {
            if (chat is null)
                return new UnsupportedMediaTypeResult();

            var additionResult = await repository.AddChat(chat);
            if (additionResult)
                return new OkResult();
            else
                return new BadRequestResult();
        }
    }
}
