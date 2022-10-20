using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SnackJobs.Api.Models.Adress;
using SnackJobs.Api.Tiers.Business.Abstract;
using SnackJobs.Api.Tiers.Core;

namespace SnackJobs.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Create([FromBody]CreateLocationModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var location = model.Adapt<Location>();
            location.UserId = new Guid(HttpContext.User.FindFirst("id").Value);

            var locationResponse = await _locationService.CreateAsync(location);

            if (!locationResponse.Success)
                return BadRequest(locationResponse.Message);

            return Ok(locationResponse.Extra);
        }
    }
}