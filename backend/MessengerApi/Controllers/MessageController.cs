﻿using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using MessengerApi.Models;
using Microsoft.EntityFrameworkCore;


namespace MessengerApi.Controllers
{
    [Controller]
    [Route("api/[controller]/{chatId?}")]
    public class MessageController : ControllerBase
    {
        private MessageStore _store;

        public MessageController(MessageStore store)
        {
            _store = store;
        }

        [HttpGet]
        public async Task<JsonResult> GetMessages(int chatId)
        {
            var messages = await _store.Messages.Where(m => m.ChatId == chatId)
                .Select(m => new { id = m.Id, userName = m.UserName, messageText = m.MessageText })
                .ToArrayAsync();

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
