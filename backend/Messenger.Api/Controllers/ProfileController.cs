using Messenger.Model;
using Messenger.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace Messenger.Api.Controllers
{
    public sealed class ProfileController : MessengerApiController
    {
        private readonly ProfileService profileService;
        private readonly AuthService    authService;

        public ProfileController(ProfileService profileService, AuthService authService)
        {
            this.profileService = profileService;
            this.authService    = authService;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetProfile()
        {
            var id = authService.CurrentUserId;
            var profile = await profileService.GetProfile(id);

            return new JsonResult(profile);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UpdateProfile([FromBody] ProfileModel value)
        {
            if (value is null) { return new UnsupportedMediaTypeResult(); }

            var id = authService.CurrentUserId;
            await profileService.UpdateProfile(id, value);

            return new OkResult();
        }
    }
}
