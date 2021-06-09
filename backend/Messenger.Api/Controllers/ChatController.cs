using Messenger.Store;
using Messenger.Store.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;


namespace Messenger.Api.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public sealed class ChatController : ControllerBase
    {
        private readonly IRepository<Chat> _repository;

        public ChatController(IRepository<Chat> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetChats()
        {
            var chats = await _repository.GetAll();
            var cleanedChats = chats.Select(chat => new { chat.Id, chat.Name });

            return new JsonResult(cleanedChats);
        }

        [HttpPut]
        public async Task<IActionResult> AddChat([FromBody] Chat chat)
        {
            if (chat is null)
                return new UnsupportedMediaTypeResult();

            var additionResult = await _repository.Add(chat);
            if (additionResult)
                return new OkResult();
            else
                return new BadRequestResult();
        }
    }
}
