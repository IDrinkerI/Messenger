using Messenger.Data.Entities;
using Messenger.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace Messenger.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class ChatController : ControllerBase
    {
        private readonly ChatService chatService;

        public ChatController(ChatService chatService)
        {
            this.chatService = chatService;
        }

        [HttpGet]
        public async Task<IActionResult> GetChats()
        {
            var chats = await chatService.GetChats();

            return new JsonResult(chats);
        }

        [HttpPut]
        public async Task<IActionResult> AddChat([FromBody] ChatEntity chat)
        {
            if (chat is null)
                return new UnsupportedMediaTypeResult();

            await chatService.AddChat(chat);
            return new OkResult();
        }
    }
}
