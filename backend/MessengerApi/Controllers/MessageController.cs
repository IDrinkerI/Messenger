using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessengerApi.Models;
using System.Text.Json;

namespace MessengerApi.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetMessages()
        {
            var messages = new MessageModel[]
            {
                new MessageModel("bot", "hallo"),
                new MessageModel("bot", "Message 1"),
                new MessageModel("bot", "Message 2"),
                new MessageModel("bot", "Message 3"),
            };

            return new JsonResult(messages);
        }
    }
}
