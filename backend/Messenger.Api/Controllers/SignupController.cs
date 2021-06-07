﻿using System.Threading.Tasks;
using Messenger.Data;
using Messenger.Data.Models;
using Microsoft.AspNetCore.Mvc;


namespace Messenger.Api.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public sealed class SignupController : ControllerBase
    {
        private readonly UserRepository _repository;

        public SignupController(UserRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Signup([FromBody] User newUser)
        {
            // TODO: remove unnecessary checks 
            if (newUser is null ||
                newUser.Email is null ||
                newUser.Password is null)
            {
                return BadRequest(new { errorText = "wrong user info" });
            }

            var user = await _repository.GetUser(newUser.Email);
            if (!(user is null)) { return BadRequest(new { erroeText = "Than email is taken." }); }

            _repository.AddUser(newUser);

            return new OkResult();
        }
    }
}
