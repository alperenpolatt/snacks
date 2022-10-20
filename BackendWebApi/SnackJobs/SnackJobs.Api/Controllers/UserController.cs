using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using MapsterMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SnackJobs.Api.Tiers.Business.Abstract;
using SnackJobs.Api.Tiers.Data;

namespace SnackJobs.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserWithRole()
        {
            var email = HttpContext.User.FindFirst(ClaimTypes.Email).Value;
            var userResponse = await _userService.GetUserByEmailWithRoleAsync(email);

            if (!userResponse.Success)
                return BadRequest(userResponse.Message);

            return Ok(userResponse.Extra);
        }

        [HttpGet]
        public IActionResult GetUserRole()
        {
            var role = HttpContext.User.FindFirst(ClaimTypes.Role).Value;
            return Ok(role);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserDetail()
        {
            var id = HttpContext.User.FindFirst("id").Value;
            var role = HttpContext.User.FindFirst(ClaimTypes.Role).Value;
            if (role == CustomRoles.Employee.ToString())
            {
                var response = await _userService.GetEmployeeUserByIdWithRoleAsync(new Guid(id));
                if (!response.Success)
                    return BadRequest(response.Message);
                return Ok(response.Extra);
            }
            else if (role == CustomRoles.Employer.ToString())
            {
                var response = await _userService.GetEmployerUserByIdWithRoleAsync(new Guid(id));
                if (!response.Success)
                    return BadRequest(response.Message);
                return Ok(response.Extra);
            }
            else
                return BadRequest("Admin does not have");
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetPublicProfile([FromRoute] string userId)
        {
            var response = await _userService.GetPublicProfileByIdAsync(new Guid(userId));
            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response.Extra);
        }
        [HttpGet]
        [Authorize(Policy = nameof(CustomRoles.Admin))]
        public async Task<IActionResult> GetAllUsers()
        {
            var response =await _userService.GetAllUsersWithRoleAsync();
            if (!response.Success)
                return BadRequest(response.Message);
            return Ok(response.Extra);
        }
        [HttpDelete("{userId}")]
        [Authorize(Policy = nameof(CustomRoles.Admin))]
        public async Task<IActionResult> DeleteUser([FromRoute] string userId)
        {
            var response = await _userService.DeleteUserAsync(new Guid(userId));
            if (!response.Success)
                return BadRequest(response.Message);
            return Ok(response.Extra);
        }
    }
}