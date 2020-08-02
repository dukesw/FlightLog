using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using DukeSoftware.GuardClauses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/locations")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService locationService; 

        public LocationController(ILocationService locationService)
        {
            Guard.AgainstNull(locationService, "locationService");
            this.locationService = locationService;
        }

        [HttpGet]
        [Authorize(Roles = "flightlog-api.admin, flightlog-api.read")]
        public async Task<ActionResult> List()
        {
            var locations = await locationService.GetLocationsAsync();
            return Ok(locations.ToArray());
        }

        [HttpPost]
        [Authorize(Roles = "flightlog-api.admin, flightlog-api.write")]
        public async Task<ActionResult<Location>> Post([FromBody] Location newLocation)
        {
            try
            {
                var result = await locationService.AddLocationAsync(newLocation);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Error adding location");
            }
        }

    }
}
