using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessengerApi.Models;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace MessengerApi.Controllers
{
    [Controller]
    [Route("api/[controller]/{chatId?}")]
    public class MessageController : ControllerBase
    {
        private Store _store;

        public MessageController(Store store)
        {
            _store = store;
        }

        [HttpGet]
        public JsonResult GetMessages(int chatId)
        {
            var messages = _store.Messages.Include(m => m.Chat).Where(m => m.ChatId == chatId).ToArray();
            return new JsonResult(messages);
        }

        [HttpPost]
        public async Task<StatusCodeResult> AddMessage([FromBody] Message message)
        {
            if (message is null)
                return new UnsupportedMediaTypeResult();

            if (message.UserName is null)
                return new UnsupportedMediaTypeResult();

            var chat = await _store.Chats.FirstOrDefaultAsync(chat => chat.Id == message.ChatId);
            // TODO: alter this trash
            if (chat is null) { return new OkResult(); }

            await _store.Messages.AddAsync(message);
            await _store.SaveChangesAsync();
            return new OkResult();
        }
    }
}
