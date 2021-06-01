﻿using MessengerApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> GetChats()
        {
            var chats = await _store.Chats.Select(chat => new { chat.Id, chat.Name })
                .ToArrayAsync();

            return new JsonResult(chats);
        }

        [HttpPost]
        public async Task<IActionResult> AddChat([FromBody] Chat chat)
        {
            if (chat is null)
                return new UnsupportedMediaTypeResult();

            await _store.Chats.AddAsync(chat);
            await _store.SaveChangesAsync();
            return new OkResult();
        }
    }
}
