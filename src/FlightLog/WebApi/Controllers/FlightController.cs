using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DukeSoftware.FlightLog.Shared.Dtos;
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
        [Authorize(Roles = "User, Admin")]
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

        [HttpGet("recent")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult> GetRecent(int accountId)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                var flights = await _flightService.GetRecentFlightsAsync(accountId);
                return Ok(flights);
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult<FlightDto>> GetById(int accountId, int id)
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

        [HttpGet("from/{startDate}/to/{endDate}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult<List<FlightDto>>> GetByDateRange(int accountId, DateTime startDate, DateTime endDate)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                var flights = await _flightService.GetFlightsByDateAsync(accountId, startDate, endDate);
                return Ok(flights);
            }
            catch (ArgumentNullException)
            {
                return NotFound($"Error finding flights from {startDate} to {endDate}");
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
        }


        [HttpGet("model/{modelId}")]
        [Authorize(Roles = "User, Admin")]
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

        [HttpGet("model/{modelId}/from/{startDate}/to/{endDate}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult<List<FlightDto>>> GetByModelIdAndDateRange(int accountId, DateTime startDate, DateTime endDate, int modelId)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                var flights = await _flightService.GetFlightsByDateAndModelAsync(accountId, startDate, endDate, modelId);
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
        [Authorize(Roles = "User, Admin")]
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

        [HttpGet("group/week/from/{startDate}/to/{endDate}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult<FlightSummaryDto>> GetGroupedFlightsByWeekForDateRange(int accountId, DateTime startDate, DateTime endDate)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                // Date guards
                Guard.AgainstNull(startDate, "startDate");
                Guard.AgainstNull(endDate, "endDate");

                var flights = await _flightService.GetGroupedFlightsByWeekForDates(accountId, startDate, endDate);
                return Ok(flights);
            }
            catch (ArgumentNullException)
            {
                return NotFound($"Error finding flights for summary");
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
        }

        [HttpGet("group/month/from/{startDate}/to/{endDate}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult<FlightSummaryDto>> GetGroupedFlightsByMonthForDateRange(int accountId, DateTime startDate, DateTime endDate)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                // Date guards
                Guard.AgainstNull(startDate, "startDate");
                Guard.AgainstNull(endDate, "endDate");

                var flights = await _flightService.GetGroupedFlightsByMonthForDates(accountId, startDate, endDate);
                return Ok(flights);
            }
            catch (ArgumentNullException)
            {
                return NotFound($"Error finding flights for summary");
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
        }

        [HttpGet("group/monthandmodel/from/{startDate}/to/{endDate}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult<FlightSummaryDto>> GetGroupedFlightsByMonthAndModelForDateRange(int accountId, DateTime startDate, DateTime endDate)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                // Date guards
                Guard.AgainstNull(startDate, "startDate");
                Guard.AgainstNull(endDate, "endDate");

                var flights = await _flightService.GetGroupedFlightsByMonthAndModelForDates(accountId, startDate, endDate);
                return Ok(flights);
            }
            catch (ArgumentNullException)
            {
                return NotFound($"Error finding flights for summary");
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
        }


        [HttpGet("summary/from/{startDate}/to/{endDate}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult<FlightSummaryDto>> GetSummaryByDateRange(int accountId, DateTime startDate, DateTime endDate)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                // Date guards
                Guard.AgainstNull(startDate, "startDate");
                Guard.AgainstNull(endDate, "endDate");

                var flights = await _flightService.GetFlightSummaryByDateRange(accountId, startDate, endDate);
                return Ok(flights);
            }
            catch (ArgumentNullException)
            {
                return NotFound($"Error finding flights for summary");
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
        }

        [HttpGet("summary/{modelId}/from/{startDate}/to/{endDate}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult<FlightSummaryDto>> GetSummaryByModelAndDateRange(int accountId, int modelId, DateTime startDate, DateTime endDate)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                // Date guards
                Guard.AgainstNull(startDate, "startDate");
                Guard.AgainstNull(endDate, "endDate");

                var flights = await _flightService.GetFlightSummaryByModelAndDateRange(accountId, modelId, startDate, endDate);
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
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult<FlightDto>> Post(int accountId, [FromBody] FlightDto newFlight)
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
            catch (Exception e)
            {
                return BadRequest($"Error adding flight");
            }
        }

        [HttpPut]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult<FlightDto>> Put(int accountId, [FromBody] FlightDto flight)
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
        [Authorize(Roles = "User, Admin")]
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