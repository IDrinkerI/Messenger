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
        private List<MessageModel> _messages;

        public MessageController()
        {
            _messages = new List<MessageModel>()
            {
                new MessageModel("bot", "hallo"),
                new MessageModel("bot", "Message 1"),
                new MessageModel("bot", "Message 2"),
                new MessageModel("bot", "Message 3"),
            };
        }

        [HttpGet]
        public JsonResult GetMessages()
        {
            return new JsonResult(_messages);
        }

        [HttpPost]
        public StatusCodeResult AddMessage(MessageModel message)
        {
            if (message is null)
                return new UnsupportedMediaTypeResult();

            _messages.Add(message);
            return new OkResult();
        }
    }
}
