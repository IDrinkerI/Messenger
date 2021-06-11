using Messenger.Store;
using Messenger.Store.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace Messenger.Api.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
       private readonly ProfileRepository repository;

        public ProfileController(ProfileRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProfile()
        {
            var id = 1;
            var profile = await repository.GetProfile(id);

            return new JsonResult(profile);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProfile([FromBody] Profile value)
        {
            if (value is null) { return new UnsupportedMediaTypeResult(); }

            // TODO: need cookes
            var id = value.Id;

            var updateResult = await repository.UpdateProfile(id, value);
            if (updateResult)
                return new OkResult();
            else
                return new BadRequestResult();
        }
    }
}
