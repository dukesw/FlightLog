using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Exceptions;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using DukeSoftware.GuardClauses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/{accountId}/locations")]
    [ApiController]
    public class LocationController : BaseApiController
    {
        private readonly ILocationService locationService; 

        public LocationController(ILocationService locationService)
        {
            Guard.AgainstNull(locationService, "locationService");
            this.locationService = locationService;
        }

        [HttpGet]
        [Authorize(Roles = "flightlog-api.read, flightlog-api.admin")]
        public async Task<ActionResult> List(int accountId)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                var locations = await locationService.GetLocationsAsync(accountId);
                return Ok(locations.ToArray());
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
        }

        [HttpPost]
        [Authorize(Roles = "flightlog-api.admin, flightlog-api.write")]
        public async Task<ActionResult<Location>> Post(int accountId, [FromBody] Location newLocation)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                var result = await locationService.AddLocationAsync(accountId, newLocation);
                return Ok(result);
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
            catch (Exception)
            {
                return BadRequest("Error adding location");
            }
        }

    }
}
