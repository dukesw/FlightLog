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

namespace WebApi.Controllers { 
    /// <summary>
    /// The BatteryController has some standard CRUD type methods in a REST style alongside some more "ProcessName" methods
    /// </summary>
    [Route("/api/{accountId}/batteries")]
    public class BatteryController : BaseApiController
    {
        private readonly IBatteryService _batteryService;

        public BatteryController(IBatteryService batteryService)
        {
            _batteryService = batteryService;
        }

        [HttpGet]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult> List(int accountId)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                var batteries = await _batteryService.ListBatteriesAsync(accountId);
                return Ok(batteries.ToArray());
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult> GetById(int accountId, int id)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                var battery = await _batteryService.GetBatteryByIdAsync(accountId, id);
                return Ok(battery);
            }
            catch (ArgumentNullException)
            {
                return NotFound($"Error finding battery {id}");
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
        }

        [HttpPost]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult<Battery>> Post(int accountId, [FromBody] Battery newBattery)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                var result = await _batteryService.EnterNewBatteryAsync(accountId, newBattery);
                return Ok(result);
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
            catch (Exception)
            {
                return BadRequest("Error adding battery");
            }
        }

        // TODO Fix this or create a better implemetnation with some rules for updating batteries
        [HttpPut]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult<Battery>> Put(int accountId, [FromBody] Battery battery)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                var result = await _batteryService.UpdateBatteryAsync(accountId, battery);
                return Ok(result);
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Error with input battery");
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
            catch (Exception)
            {
                return BadRequest($"Error updating battery");
            }
        }

        // TODO Fix this method
        [HttpDelete("{id}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult> Delete(int accountId, int id)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                await _batteryService.DeleteBatteryAsync(accountId, id);
                return Ok();
            }
            catch (BatteryNotFoundException)
            {
                return NotFound($"Error finding battery {id} to delete");
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
            catch (Exception)
            {
                return Conflict($"Error deleting battery {id}");
            }

        }
    }
}
