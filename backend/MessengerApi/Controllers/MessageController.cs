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
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private Store _store;

        public MessageController(Store store)
        {
            _store = store;
        }

        [HttpGet]
        public async Task<JsonResult> GetMessages()
        {
            var messages = await _store.Messages.ToListAsync();
            return new JsonResult(messages);
        }

        [HttpPost]
        public async Task<StatusCodeResult> AddMessage([FromBody] Message message)
        {
            if (message is null)
                return new UnsupportedMediaTypeResult();

            if (message.UserName is null)
                return new UnsupportedMediaTypeResult();

            await _store.Messages.AddAsync(message);
            await _store.SaveChangesAsync();
            return new OkResult();
        }
    }
}
