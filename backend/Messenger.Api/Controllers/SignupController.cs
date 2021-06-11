using System.Threading.Tasks;
using Messenger.Store;
using Messenger.Store.Models;
using Microsoft.AspNetCore.Mvc;


namespace Messenger.Api.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    internal sealed class SignupController : ControllerBase
    {
        private readonly UserRepository repository;

        public SignupController(UserRepository repository)
        {
            this.repository = repository;
        }

        [HttpPut]
        public async Task<IActionResult> Signup([FromBody] User newUser)
        {
            // TODO: remove unnecessary checks 
            if (newUser is null ||
                newUser.Email is null ||
                newUser.Password is null)
            {
                return BadRequest(new { errorText = "wrong user info" });
            }

            var user = await repository.GetUser(newUser.Email);
            if (!(user is null)) { return BadRequest(new { erroeText = "Than email is taken." }); }

            await repository.AddUser(newUser);

            return new OkResult();
        }
    }
}
