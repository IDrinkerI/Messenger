using MessengerApi.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;


namespace MessengerApi.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class SigninController : ControllerBase
    {
        private Store _store;

        public SigninController(Store store)
        {
            _store = store;
        }

        [HttpPost]
        public async Task<IActionResult> Singin([FromBody] User singinData)
        {
            var user = await _store.Users.FirstOrDefaultAsync((u) =>
                u.Email == singinData.Email && u.Password == singinData.Password);

            if (user is null) { return BadRequest(new { errorText = "Invalid username or password." }); }

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
            };

            var claimIdentity = new ClaimsIdentity(claims, "Messenger", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            var claimPrincipal = new ClaimsPrincipal(claimIdentity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal);

            return new OkResult();
        }
    }
}
