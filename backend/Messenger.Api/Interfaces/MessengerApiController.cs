using Microsoft.AspNetCore.Mvc;


namespace Messenger.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class MessengerApiController : ControllerBase { }
}
