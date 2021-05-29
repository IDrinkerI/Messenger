using MessengerApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessengerApi.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        [HttpGet]
        public async Task<JsonResult> GetProfile()
        {
            var profile = new Profile()
            {
                Id = 0,
                Nickname = "Backend",
            };

            return new JsonResult(profile);
        }

        [HttpPost]
        public async Task<StatusCodeResult> UpdateProfile([FromBody] Profile profile)
        {
            if (profile is null) return new UnsupportedMediaTypeResult();

            else return new OkResult();
        }
    }
}
