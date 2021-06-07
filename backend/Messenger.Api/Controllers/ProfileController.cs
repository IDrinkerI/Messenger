using MessengerApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;


namespace MessengerApi.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        private Store _store;

        public ProfileController(Store store)
        {
            _store = store;
        }

        [HttpGet]
        public async Task<IActionResult> GetProfile()
        {
            var id = 1;
            var profile = await _store.Profiles.FirstOrDefaultAsync(p => p.Id == id);

            return new JsonResult(profile);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProfile([FromBody] Profile value)
        {
            if (value is null) { return new UnsupportedMediaTypeResult(); }

            // TODO: need cookes
            var id = value.Id;

            var profile = _store.Profiles.FirstOrDefault(p => p.Id == id);
            if (profile is null) { return new UnsupportedMediaTypeResult(); }

            profile.CopyFrom(value);
            await _store.SaveChangesAsync();

            return new OkResult();
        }
    }
}
