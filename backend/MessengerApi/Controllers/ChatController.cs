using MessengerApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessengerApi.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private Store _store;

        public ChatController(Store store)
        {
            _store = store;
        }

        [HttpGet]
        public  JsonResult GetChats()
        {
            var chats =  _store.Chats.Select(chat => new { chat.Id, chat.Name }).ToList();
            return new JsonResult(chats);
        }

        [HttpPost]
        public async Task<StatusCodeResult> AddChat([FromBody] Chat chat)
        {
            if (chat is null)
                return new UnsupportedMediaTypeResult();

            await _store.Chats.AddAsync(chat);
            await _store.SaveChangesAsync();
            return new OkResult();
        }
    }
}
