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
        IRepository<Profile> _repository;

        public ProfileController(IRepository<Profile> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProfile()
        {
            var id = 1;
            var profile = await _repository.Get(id);

            return new JsonResult(profile);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProfile([FromBody] Profile value)
        {
            if (value is null) { return new UnsupportedMediaTypeResult(); }

            // TODO: need cookes
            var id = value.Id;

            var updateResult = await _repository.Update(id, value);
            if (updateResult)
                return new OkResult();
            else
                return new BadRequestResult();
        }
    }
}
