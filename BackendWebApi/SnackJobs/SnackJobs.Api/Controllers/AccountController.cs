using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SnackJobs.Api.Models.User;
using SnackJobs.Api.Tiers.Business.Abstract;
using SnackJobs.Api.Tiers.Data;

namespace SnackJobs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class AccountController : ControllerBase
    {
        private readonly ICustomIdentityManager _userManager;
        public AccountController(ICustomIdentityManager userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {

            return new string[] { "Under  ", "Development", "...." ,nameof(CustomRoles.Employee)};
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]RegisterUserModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userResponse = await _userManager.RegisterAsync(model);

            if (!userResponse.Success)
                return BadRequest(userResponse.Message);

            return Ok(userResponse.Extra);

        }
        [HttpPost("AccessToken")]
        public async Task<IActionResult> AccessToken([FromBody] LoginModel model)
        {
            var authResponse = await _userManager.LoginAsync(model.Email, model.Password);

            if (!authResponse.Success)
            {
                return BadRequest(authResponse.Message);
            }

            return Ok(authResponse);
        }
        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenModel model)
        {
            var authResponse = await _userManager.RefreshTokenAsync(model.Token, model.RefreshToken);

            if (!authResponse.Success)
            {
                return BadRequest(authResponse.Message);
            }

            return Ok(authResponse);
        }
    }
}