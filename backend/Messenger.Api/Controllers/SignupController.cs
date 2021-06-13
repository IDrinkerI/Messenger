using System.Threading.Tasks;
using Messenger.Data;
using Messenger.Data.Entities;
using Messenger.Model;
using Messenger.Service;
using Microsoft.AspNetCore.Mvc;


namespace Messenger.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class SignupController : ControllerBase
    {
        private readonly AuthService authService;

        public SignupController(AuthService authService)
        {
            this.authService = authService;
        }

        [HttpPut]
        public async Task<IActionResult> Signup([FromBody] AuthInfoModel newUser)
        {
            // TODO: remove unnecessary checks 
            if (newUser is null ||
                newUser.Email is null)
            {
                return BadRequest(new { errorText = "wrong user info" });
            }

            var check = await authService.Contains(newUser);
            if (!check) { return BadRequest(new { erroeText = "Than email is taken." }); }

            await authService.AddUser(newUser);

            return new OkResult();
        }
    }
}
