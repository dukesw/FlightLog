using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Exceptions;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using DukeSoftware.GuardClauses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers
{
    [Route("/api/{accountId}/batteryTypes")]
    public class BatteryTypeController : BaseApiController
    {
        private readonly IBatteryService _batteryService;

        public BatteryTypeController(IBatteryService batteryService)
        {
            _batteryService = batteryService;
        }

        [HttpGet]
        [Authorize(Roles = "flightlog-api.admin, flightlog-api.read")]
        public async Task<ActionResult> Get(int accountId)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                var batteryTypes = await _batteryService.ListBatteryTypesAsync(accountId);
                return Ok(batteryTypes.ToArray());
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "flightlog-api.admin, flightlog-api.read")]
        public async Task<ActionResult> GetById(int accountId, int id)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                var batteryType = await _batteryService.GetBatteryTypeByIdAsync(accountId, id);
                return Ok(batteryType);
            } 
            catch(ArgumentNullException)
            {
                return NotFound($"Error finding battery type {id}");
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
        }

        [HttpPost]
        [Authorize(Roles = "flightlog-api.admin, flightlog-api.write")]
        public async Task<ActionResult> AddNew(int accountId, [FromBody] BatteryType batteryType)
        {
            // Validate the input
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                var result = await _batteryService.EnterNewBatteryTypeAsync(accountId, batteryType);
                return Ok(result);
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
            catch (Exception)
            {
                return BadRequest("Error adding battery type");
            }
        }

        [HttpPut]
        [Authorize(Roles = "flightlog-api.admin, flightlog-api.write")]
        public async Task<ActionResult> Update(int accountId, [FromBody] BatteryType batteryType)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                var result = await _batteryService.UpdateBatteryTypeAsync(accountId, batteryType);
                return Ok(result);
            } 
            catch (ArgumentNullException)
            {
                return BadRequest("Error with input battery type");
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
            catch (Exception)
            {
                return BadRequest("Error updating battery type");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "flightlog-api.admin, flightlog-api.write")]
        public async Task<ActionResult> Delete(int accountId, int id)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                await _batteryService.DeleteBatteryTypeAsync(accountId, id);
                return Ok();
            }
            catch (BatteryTypeNotFoundException)
            {
                return NotFound($"Error finding battery type {id} to delete");
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
            catch (Exception)
            {
                return Conflict($"Error deleting battery type {id}");
            }
        }
    }   
}
    