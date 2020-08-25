using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DukeSoftware.FlightLog.ApplicationCore.Dtos;
using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Exceptions;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using DukeSoftware.GuardClauses;
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
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                var flights = await _flightService.GetFlightsAsync(accountId);
                return Ok(flights);
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "flightlog-api.admin, flightlog-api.read")]
        public async Task<ActionResult<Flight>> GetById(int accountId, int id)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                var flight = await _flightService.GetFlightByIdAsync(accountId, id);
                return Ok(flight);
            }
            catch (ArgumentNullException)
            {
                return NotFound($"Error finding flight {id}");
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
        }

        [HttpGet("model/{modelId}")]
        [Authorize(Roles = "flightlog-api.admin, flightlog-api.read")]
        public async Task<ActionResult<List<FlightDto>>> GetByModelId(int accountId, int modelId)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                var flights = await _flightService.GetFlightsByModelAsync(accountId, modelId);
                return Ok(flights);
            }
            catch (ArgumentNullException)
            {
                return NotFound($"Error finding flights for model {modelId}");
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
        }

        [HttpGet("summary/{modelId}")]
        [Authorize(Roles = "flightlog-api.admin, flightlog-api.read")]
        public async Task<ActionResult<FlightSummaryDto>> GetSummaryByModelId(int accountId, int modelId)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                var flights = await _flightService.GetFlightSummaryByModelAsync(accountId, modelId);
                return Ok(flights);  
            }
            catch (ArgumentNullException)
            {
                return NotFound($"Error finding flights for model {modelId}");
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
        }


        [HttpPost]
        [Authorize(Roles = "flightlog-api.admin, flightlog-api.write")]
        public async Task<ActionResult<Flight>> Post(int accountId, [FromBody] Flight newFlight)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                var result = await _flightService.AddFlightAsync(accountId, newFlight);
                return Ok(result);
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Error with input flight");
            }
            catch (AccountConflictException)
            {
                return Forbid();
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
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                var result = await _flightService.UpdateFlightAsync(accountId, flight);
                return Ok(result);
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Error with input flight");
            }
            catch (AccountConflictException)
            {
                return Forbid();
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
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                await _flightService.DeleteFlightAsync(accountId, id);
                return Ok();
            }
            catch (ArgumentNullException)
            {
                return NotFound($"Error finding flight {id} to delete");
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
            catch (Exception)
            {
                // Not expecting this to trigger as any flight can be deleted even if it has a model, location etc... 
                return Conflict("Error deleting flight {id}");  
            }
        }
    }
}