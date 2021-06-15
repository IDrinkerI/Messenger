using Messenger.Model;
using Messenger.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;


namespace Messenger.Api.Controllers
{
    public sealed class SigninController : MessengerApiController
    {
        private readonly AuthService authService;

        public SigninController(AuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Signin([FromBody] AuthInfoModel signinData)
        {
            var checkResult = await authService.CheckPassword(signinData);

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
