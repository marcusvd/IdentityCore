using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authentication.Contract;
using Authentication.Entities;
using Authentication.Operations;
using Authentication.ViewDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IdentityCore.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserOperation _USER_OP;


        public AuthenticationController(IUserOperation USER_OP)
        {
            _USER_OP = USER_OP;
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto UserNew)
        {
            try
            {
                if (UserNew == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Entity {UserNew} is null");
                }
                var createUser = await _USER_OP.CreateAsync(UserNew);

                return Ok(createUser);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error controller: {ex.Message}");
            }

        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            try
            {
                if (login == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Entity {login} is null");
                }
                var LoginResult = await _USER_OP.LoginAsync(login);

                if (LoginResult.Succeeded)
                {
                    return Ok("you are logged on.");
                }
                return Ok(LoginResult);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error controller: {ex.Message}");
            }
        }



        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            try
            {
                if (id == null) return StatusCode(StatusCodes.Status500InternalServerError, $"id is null");

                var deleteResult = await _USER_OP.DeleteAsync(id);

                if (deleteResult)
                {
                    return Ok("User is deleted.");
                }

                return Ok(deleteResult);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error controller: {ex.Message}");
            }
        }
        
        [HttpGet("get/{id}")]
        public AppUser GetById(string id)
        {
            try
            {
                if (id == null) throw new Exception($"id is null");

                var GetResult = _USER_OP.FindById(id);

                return GetResult;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error controller: {ex.Message}");
            }
        }





    }
}
