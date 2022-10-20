    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SnackJobs.Api.Models;
using SnackJobs.Api.Models.Application.Given;
using SnackJobs.Api.Tiers.Business.Abstract;
using SnackJobs.Api.Tiers.Core.Applications;
using SnackJobs.Api.Tiers.Data;

namespace SnackJobs.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors]
    public class GivenApplicationController : ControllerBase
    {
        private readonly IGivenApplicationService _givenApplicationService;
        private readonly ILocationService _locationService;
        public GivenApplicationController(IGivenApplicationService givenApplicationService, ILocationService locationService)
        {
            _givenApplicationService = givenApplicationService;
            _locationService = locationService;
        }

        [HttpPost]
        [Authorize(Policy = nameof(CustomRoles.Employer))]
        public async Task<IActionResult> RegisterApplication([FromBody]RegisterApplicationModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var givenApp = model.Adapt<GivenApplication>();

            givenApp.UserId = new Guid(HttpContext.User.FindFirst("id").Value);
            var givenAppResponse = await _givenApplicationService.RegisterApplicationAsync(givenApp);

            if (!givenAppResponse.Success)
                return BadRequest(givenAppResponse.Message);

            return Ok(givenAppResponse.Extra);
        }
        //By Employer
        [HttpGet]
        [Authorize(Policy = nameof(CustomRoles.Employer))]
        public async Task<IActionResult> GetApplications()
        {
            var userId = new Guid(HttpContext.User.FindFirst("id").Value);
            var givenAppResponse = await _givenApplicationService.GetApplications(userId);

            if (!givenAppResponse.Success)
                return BadRequest(givenAppResponse.Message);

            return Ok(givenAppResponse.Extra);
        }
        [HttpGet("{givenApplicationId}")]
        public async Task<IActionResult> GetApplicationDetail([FromRoute] string givenApplicationId)
        {
           
            var givenAppResponse = await _givenApplicationService.GetApplicationWithDoneAppsDetail(new Guid(givenApplicationId));

            if (!givenAppResponse.Success)
                return BadRequest(givenAppResponse.Message);

            return Ok(givenAppResponse.Extra);
        }
        [HttpGet("{givenApplicationId}")]
        public async Task<IActionResult> GetPublicApplicationDetail([FromRoute] string givenApplicationId)
        {

            var givenAppResponse = await _givenApplicationService.GetPublicGivenApplicationDetailAsync(new Guid(givenApplicationId));

            if (!givenAppResponse.Success)
                return BadRequest(givenAppResponse.Message);

            return Ok(givenAppResponse.Extra);
        }
        [HttpPost]
        public async Task<IActionResult> GetApplicationsByDistance([FromBody] ApplicationsByDistance model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (model.Lat == 0 && model.Lon == 0)
            {// if client does not give coords
                var userId = new Guid(HttpContext.User.FindFirst("id").Value);
                var locationResponse = await _locationService.GetByUserIdAsync(userId);
                if(!locationResponse.Success) // Examine Null scenario
                    return BadRequest(locationResponse.Message);
                model.Lat = locationResponse.Extra.Lat;
                model.Lon = locationResponse.Extra.Lon;
            }

            var givenAppResponse = await _givenApplicationService.GetApplicationsByDistance(model);

            if (!givenAppResponse.Success)
                return BadRequest(givenAppResponse.Message);

                return Ok(givenAppResponse.Extra);
        }
    }
}