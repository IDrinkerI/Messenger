using Messenger.Data.Entities;
using Messenger.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;


namespace Messenger.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class ChatController : ControllerBase
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
        public async Task<IActionResult> AddChat([FromBody] ChatEntity chat)
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
