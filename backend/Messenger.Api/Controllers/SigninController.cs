using Messenger.Data;
using Messenger.Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;


namespace Messenger.Api.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public sealed class SigninController : ControllerBase
    {
        private readonly UserRepository _repository;

        public SigninController(UserRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Signin([FromBody] User signinData)
        {
            var checkResult = await _repository.CheckPassword(signinData.Email, signinData.Password);

            if (!checkResult)
                return BadRequest(new { errorText = "Invalid username or password." });

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, signinData.Email),
            };

            var claimIdentity = new ClaimsIdentity(claims, "Messenger", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            var claimPrincipal = new ClaimsPrincipal(claimIdentity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal);

            return new OkResult();
        }
    }
}
