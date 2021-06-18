using Messenger.Model;
using Messenger.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace Messenger.Api.Controllers
{
    public sealed class SignupController : MessengerApiController
    {
        private readonly IAuthService authService;

        public SignupController(IAuthService authService) =>
            this.authService = authService;

        [HttpPut]
        public async Task<IActionResult> Signup([FromBody] AuthInfoModel newUser)
        {
            // TODO: remove unnecessary checks 
            if (newUser is null       ||
                newUser.Email is null ||
                newUser.Password is null)
            {
                return BadRequest(new { errorText = "wrong user info" });
            }

            if (await authService.Contains(newUser))
                return BadRequest(new { erroeText = "Than email is taken." });

            await authService.AddUser(newUser);

            return new OkResult();
        }
    }
}
