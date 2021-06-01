using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessengerApi.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MessengerApi.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class SignupController : ControllerBase
    {
        private Store _store;

        public SignupController(Store store)
        {
            _store = store;
        }

        [HttpPost]
        public async Task<IActionResult> Singup([FromBody] User newUser)
        {
            if (newUser is null ||
                newUser.Email is null ||
                newUser.Password is null)
            {
                return BadRequest(new { errorText = "wrong user info" });
            }

            var user = await _store.Users.FirstOrDefaultAsync(u => u.Email == newUser.Email);
            if (!(user is null)) { return BadRequest(new { erroeText = "Than email is taken." }); }

            var newProfile = new Profile()
            {
                Nickname = newUser.Email,
            };

            newUser.Profile = newProfile;
            await _store.Profiles.AddAsync(newProfile);

            await _store.Users.AddAsync(newUser);
            await _store.SaveChangesAsync();

            return new OkResult();
        }
    }
}
