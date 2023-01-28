using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Exceptions;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using DukeSoftware.FlightLog.Shared.Dtos;
using DukeSoftware.GuardClauses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    /// <summary>
    /// The BatteryController has some standard CRUD type methods in a REST style alongside some more "ProcessName" methods
    /// </summary>
    [Route("/api/{accountId}/maintenancelogs")]
    public class MaintenanceLogController : BaseApiController
    {
        private readonly IMaintenanceLogService _maintenanceLogService;

        public MaintenanceLogController(IMaintenanceLogService maintenanceLogService)
        {
            _maintenanceLogService = maintenanceLogService;
        }

        [HttpGet]
        [Authorize(Roles = "User, Admin")]
        // [Authorize]
        public async Task<ActionResult> List(int accountId)
        {
            var maintenanceLogs = await _maintenanceLogService.GetMaintenanceLogsAsync(accountId);
            return Ok(maintenanceLogs.ToArray());
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult> GetById(int accountId, int id)
        {
            try
            {
                var model = await _maintenanceLogService.GetMaintenanceLogByIdAsync(accountId, id);
                return Ok(model);
            }
            catch (ArgumentNullException)
            {
                return NotFound($"Error finding maintenance log {id}");
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
        }

        [HttpGet("model/{modelId}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult> GetByModelId(int accountId, int modelId)
        {
            try
            {
                var model = await _maintenanceLogService.GetMaintenanceLogsByModelIdAsync(accountId, modelId);
                return Ok(model);
            }
            catch (ArgumentNullException)
            {
                return NotFound($"Error finding maintenance logs for model id {modelId}");
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
        }

        [HttpPost]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult<MaintenanceLogDto>> Post(int accountId, [FromBody] MaintenanceLogDto newMaintenanceLog)
        {
            try
            {
                var result = await _maintenanceLogService.AddMaintenanceLogAsync(accountId, newMaintenanceLog);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Error adding maintenance log");
            }
        }

        [HttpPut]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult<MaintenanceLogDto>> Put(int accountId, [FromBody] MaintenanceLogDto maintenanceLog)
        {
            try
            {
                var result = await _maintenanceLogService.UpdateMaintenanceLogAsync(accountId, maintenanceLog);
                return Ok(result);
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Error with input maintenance log");
            }
            catch (Exception)
            {
                return BadRequest("Error updating maintenance log");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult> Delete(int accountId, int id)
        {
            try
            {
                await _maintenanceLogService.DeleteMaintenanceLogAsync(accountId, id);
                return Ok();
            }
            catch (ArgumentNullException)
            {
                return NotFound($"Error finding maintenance log {id} to delete");
            }
            catch (Exception)
            {
                return Conflict($"Error deleting maintenance log {id}");
            }

        }

    }
}
