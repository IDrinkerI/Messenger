using Messenger.Model;
using Messenger.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace Messenger.Api.Controllers
{
    public sealed class ProfileController : MessengerApiController
    {
        private readonly ProfileService profileService;

        public ProfileController(ProfileService profileService)
        {
            this.profileService = profileService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProfile()
        {
            var id = 1;
            var profile = await profileService.GetProfile(id);

            return new JsonResult(profile);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProfile([FromBody] ProfileModel value)
        {
            if (value is null) { return new UnsupportedMediaTypeResult(); }

            // TODO: need cookes
            var id = value.Id;

            await profileService.UpdateProfile(id, value);

            return new OkResult();
        }
    }
}
