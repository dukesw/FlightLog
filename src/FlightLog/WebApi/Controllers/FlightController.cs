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

        [HttpGet("recent/count")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult> GetRecentCount(int accountId)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                var count = await _flightService.GetRecentFlightCountAsync(accountId);
                return Ok(count);
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
        }

        [HttpGet("count")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult> GetCount(int accountId)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                var count = await _flightService.GetFlightCountAsync(accountId);
                return Ok(count);
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
        }

        [HttpGet("recent/skip/{skip}/take/{take}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult> GetRecentByPage(int accountId, int skip, int take)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                var flights = await _flightService.GetRecentFlightsPagedAsync(accountId, skip, take);
                return Ok(flights);
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
        }


        [HttpGet("skip/{skip}/take/{take}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult> GetByPage(int accountId, int skip, int take)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                var flights = await _flightService.GetFlightsPagedAsync(accountId, skip, take);
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

        [HttpGet("from/{fromDate}/to/{toDate}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult<List<FlightDto>>> GetByDateRange(int accountId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                var flights = await _flightService.GetFlightsByDateRangeAsync(accountId, fromDate, toDate);
                return Ok(flights);
            }
            catch (ArgumentNullException)
            {
                return NotFound($"Error finding flights from {fromDate} to {toDate}");
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
        }

        [HttpGet("from/{fromDate}/to/{toDate}/count")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult<List<FlightDto>>> GetFlightCountByDateRange(int accountId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                var count = await _flightService.GetFlightCountByDateRangeAsync(accountId, fromDate, toDate);
                return Ok(count);
            }
            catch (ArgumentNullException)
            {
                return NotFound($"Error finding flights from {fromDate} to {toDate}");
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
        }

        [HttpGet("from/{fromDate}/to/{toDate}/skip/{skip}/take/{take}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult<List<FlightDto>>> GetByDateRangePaged(int accountId, DateTime fromDate, DateTime toDate, int skip, int take)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                var flights = await _flightService.GetFlightsByDateRangePagedAsync(accountId, fromDate, toDate, skip, take);
                return Ok(flights);
            }
            catch (ArgumentNullException)
            {
                return NotFound($"Error finding flights from {fromDate} to {toDate}");
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

        [HttpGet("model/{modelId}/count")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult<List<FlightDto>>> GetCountByModelId(int accountId, int modelId)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                var count = await _flightService.GetFlightCountByModelAsync(accountId, modelId);
                return Ok(count);
            }
            catch (ArgumentNullException)
            {
                return NotFound($"Error finding flight count for model {modelId}");
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
        }

        [HttpGet("model/{modelId}/skip/{skip}/take/{take}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult<List<FlightDto>>> GetByModelIdPaged(int accountId, int modelId, int skip, int take)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                var flights = await _flightService.GetFlightsByModelPagedAsync(accountId, modelId, skip, take);
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


        [HttpGet("model/{modelId}/from/{fromDate}/to/{toDate}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult<List<FlightDto>>> GetByModelIdAndDateRange(int accountId, DateTime fromDate, DateTime toDate, int modelId)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                var flights = await _flightService.GetFlightsByDateRangeAndModelAsync(accountId, fromDate, toDate, modelId);
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

        [HttpGet("model/{modelId}/from/{fromDate}/to/{toDate}/count")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult<List<FlightDto>>> GetCountByModelIdAndDateRange(int accountId, DateTime fromDate, DateTime toDate, int modelId)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                var count = await _flightService.GetFlightCountByDateRangeAndModelAsync(accountId, fromDate, toDate, modelId);
                return Ok(count);
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

        [HttpGet("model/{modelId}/from/{fromDate}/to/{toDate}/skip/{skip}/take/{take}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult<List<FlightDto>>> GetByModelIdAndDateRangePaged(int accountId, DateTime fromDate, DateTime toDate, int modelId, int skip, int take)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                var flights = await _flightService.GetFlightsByDateRangeAndModelPagedAsync(accountId, fromDate, toDate, modelId, skip, take);
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

        [HttpGet("group/week/from/{fromDate}/to/{toDate}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult<FlightSummaryDto>> GetGroupedFlightsByWeekForDateRange(int accountId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                // Date guards
                Guard.AgainstNull(fromDate, "startDate");
                Guard.AgainstNull(toDate, "endDate");

                var flights = await _flightService.GetGroupedFlightsByWeekForDateRange(accountId, fromDate, toDate);
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

        [HttpGet("group/month/from/{fromDate}/to/{toDate}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult<FlightSummaryDto>> GetGroupedFlightsByMonthForDateRange(int accountId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                // Date guards
                Guard.AgainstNull(fromDate, "startDate");
                Guard.AgainstNull(toDate, "endDate");

                var flights = await _flightService.GetGroupedFlightsByMonthForDateRange(accountId, fromDate, toDate);
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

        [HttpGet("group/monthandmodel/from/{fromDate}/to/{toDate}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult<FlightSummaryDto>> GetGroupedFlightsByMonthAndModelForDateRange(int accountId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                // Date guards
                Guard.AgainstNull(fromDate, "startDate");
                Guard.AgainstNull(toDate, "endDate");

                var flights = await _flightService.GetGroupedFlightsByMonthAndModelForDateRange(accountId, fromDate, toDate);
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


        [HttpGet("summary/from/{fromDate}/to/{toDate}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult<FlightSummaryDto>> GetSummaryByDateRange(int accountId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                // Date guards
                Guard.AgainstNull(fromDate, "startDate");
                Guard.AgainstNull(toDate, "endDate");

                var flights = await _flightService.GetFlightSummaryByDateRange(accountId, fromDate, toDate);
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

        [HttpGet("summary/{modelId}/from/{fromDate}/to/{toDate}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult<FlightSummaryDto>> GetSummaryByModelAndDateRange(int accountId, int modelId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                // Date guards
                Guard.AgainstNull(fromDate, "startDate");
                Guard.AgainstNull(toDate, "endDate");

                var flights = await _flightService.GetFlightSummaryByModelAndDateRange(accountId, modelId, fromDate, toDate);
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
            catch (Exception)
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