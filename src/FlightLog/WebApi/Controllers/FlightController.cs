using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DukeSoftware.FlightLog.ApplicationCore.Dtos;
using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/{accountId}/flights")]
    [ApiController]
    public class FlightController : BaseApiController
    {
        private readonly IFlightService _flightService;

        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpGet]
        [Authorize(Roles = "flightlog-api.admin, flightlog-api.read")]
        public async Task<ActionResult> Get(int accountId)
        {
            if (!IsAccountIdOk(HttpContext, accountId))
            {
                return Forbid();
            }

            var flights = await _flightService.GetFlightsAsync(accountId);
            return Ok(flights);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "flightlog-api.admin, flightlog-api.read")]
        public async Task<ActionResult<Flight>> GetById(int accountId, int id)
        {
            if (!IsAccountIdOk(HttpContext, accountId))
            {
                return Forbid();
            }

            try
            {
                var flight = await _flightService.GetFlightByIdAsync(accountId, id);
                return Ok(flight);
            }
            catch (ArgumentNullException)
            {
                return NotFound($"Error finding flight {id}");
            }
        }

        [HttpGet("model/{modelId}")]
        [Authorize(Roles = "flightlog-api.admin, flightlog-api.read")]
        public async Task<ActionResult<List<FlightDto>>> GetByModelId(int accountId, int modelId)
        {
            if (!IsAccountIdOk(HttpContext, accountId))
            {
                return Forbid();
            }

            try
            {
                var flights = await _flightService.GetFlightsByModelAsync(accountId, modelId);
                return Ok(flights);
            }
            catch (ArgumentNullException)
            {
                return NotFound($"Error finding flights for model {modelId}");
            }
        }

        [HttpGet("summary/{modelId}")]
        [Authorize(Roles = "flightlog-api.admin, flightlog-api.read")]
        public async Task<ActionResult<FlightSummaryDto>> GetSummaryByModelId(int accountId, int modelId)
        {
            if (!IsAccountIdOk(HttpContext, accountId))
            {
                return Forbid();
            }

            try
            {
                var flights = await _flightService.GetFlightSummaryByModelAsync(accountId, modelId);
                return Ok(flights);  
            }
            catch (ArgumentNullException)
            {
                return NotFound($"Error finding flights for model {modelId}");
            }
        }


        [HttpPost]
        [Authorize(Roles = "flightlog-api.admin, flightlog-api.write")]
        public async Task<ActionResult<Flight>> Post(int accountId, [FromBody] Flight newFlight)
        {
            if (!IsAccountIdOk(HttpContext, accountId))
            {
                return Forbid();
            }

            // TODO also check the account Id passed in the flight service, throwing the apporopriate exception
            try
            {
                var result = await _flightService.AddFlightAsync(newFlight);
                return Ok(result);
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Error with input flight");
            }
            catch (Exception)
            {
                return BadRequest("Error adding flight");
            }
        }

        [HttpPut]
        [Authorize(Roles = "flightlog-api.admin, flightlog-api.write")]
        public async Task<ActionResult<Flight>> Put(int accountId, [FromBody] Flight flight)
        {
            if (!IsAccountIdOk(HttpContext, accountId))
            {
                return Forbid();
            }

            try
            {
                var result = await _flightService.UpdateFlightAsync(flight);
                return Ok(result);
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Error with input flight");
            }
            catch (Exception)
            {
                return BadRequest("Error updating flight");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "flightlog-api.admin, flightlog-api.write")]
        public async Task<ActionResult> Delete(int accountId, int id)
        {
            if (!IsAccountIdOk(HttpContext, accountId))
            {
                return Forbid();
            }

            try
            {
                await _flightService.DeleteFlightAsync(id);
                return Ok();
            }
            catch (ArgumentNullException)
            {
                return NotFound($"Error finding flight {id} to delete");
            }
            catch (Exception)
            {
                // Not expecting this to trigger as any flight can be deleted even if it has a model, location etc... 
                return Conflict("Error deleting flight {id}");  
            }
        }
    }
}