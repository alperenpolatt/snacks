using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SnackJobs.Api.Models.Application.Done;
using SnackJobs.Api.Tiers.Business.Abstract;
using SnackJobs.Api.Tiers.Core.Applications;
using SnackJobs.Api.Tiers.Data;

namespace SnackJobs.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DoneApplicationController : ControllerBase
    {
        private readonly IDoneApplicationService _doneApplicationService;
        public DoneApplicationController(IDoneApplicationService doneApplicationService)
        {
            _doneApplicationService = doneApplicationService;
        }
        
        [HttpPost]
        [Authorize(Policy = nameof(CustomRoles.Employee))]
        public async Task<IActionResult> MakeApplication([FromBody]MakeApplicationModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var doneApplication = model.Adapt<DoneApplication>();
            doneApplication.UserId = new Guid(HttpContext.User.FindFirst("id").Value);

            var doneApplicationResponse = await _doneApplicationService.MakeApplicationAsync(doneApplication);

            if (!doneApplicationResponse.Success)
                return BadRequest(doneApplicationResponse.Message);

            return Ok(doneApplicationResponse.Extra);
        }
        
        [HttpPatch]
        [Authorize(Policy = nameof(CustomRoles.Employer))]
        public async Task<IActionResult> DenyApplication([FromBody]DenyApplicationModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var doneApplication = model.Adapt<DoneApplication>();

            var doneApplicationResponse = await _doneApplicationService.DenyApplicationAsync(doneApplication);

            if (!doneApplicationResponse.Success)
                return BadRequest(doneApplicationResponse.Message);

            return Ok(doneApplicationResponse.Extra);
        }


        [HttpPatch]
        [Authorize(Policy = nameof(CustomRoles.Employer))]
        public async Task<IActionResult> AcceptApplication([FromBody]AcceptApplicationModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var doneApplication = model.Adapt<DoneApplication>();

            var doneApplicationResponse = await _doneApplicationService.AcceptApplicationAsync(doneApplication);

            if (!doneApplicationResponse.Success)
                return BadRequest(doneApplicationResponse.Message);

            return Ok(doneApplicationResponse.Extra);
        }
        [HttpPatch]
        [Authorize(Policy = nameof(CustomRoles.Employer))]
        public async Task<IActionResult> CompleteApplication([FromBody]CompleteApplicationModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var doneApplication = model.Adapt<DoneApplication>();

            var doneApplicationResponse = await _doneApplicationService.CompleteApplicationAsync(doneApplication);

            if (!doneApplicationResponse.Success)
                return BadRequest(doneApplicationResponse.Message);

            return Ok(doneApplicationResponse.Extra);
        }
        //By Employee
        [HttpGet]
        [Authorize(Policy = nameof(CustomRoles.Employee))]
        public async Task<IActionResult> GetEmployeeApplications()
        {
            
            var userId = new Guid(HttpContext.User.FindFirst("id").Value);

            var doneApplicationResponse = await _doneApplicationService.GetApplicationsAsync(userId);

            if (!doneApplicationResponse.Success)
                return BadRequest(doneApplicationResponse.Message);

            return Ok(doneApplicationResponse.Extra);
        }
    }
}