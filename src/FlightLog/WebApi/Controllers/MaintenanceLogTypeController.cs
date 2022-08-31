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
    [Route("/api/maintenancelogtypes")]
    public class MaintenanceLogTypeController : BaseApiController
    {
        private readonly IMaintenanceLogTypeService _maintenanceLogTypeService;

        public MaintenanceLogTypeController(IMaintenanceLogTypeService maintenanceLogTypeService)
        {
            _maintenanceLogTypeService = maintenanceLogTypeService;
        }

        [HttpGet]
        [Authorize(Roles = "User, Admin")]
        // [Authorize]
        public async Task<ActionResult> List()
        {
            var maintenanceLogTypes = await _maintenanceLogTypeService.GetMaintenanceLogTypesAsync();
            return Ok(maintenanceLogTypes.ToArray());
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var model = await _maintenanceLogTypeService.GetMaintenanceLogTypeByIdAsync(id);
                return Ok(model);
            }
            catch (ArgumentNullException)
            {
                return NotFound($"Error finding maintenance log type {id}");
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<MaintenanceLogTypeDto>> Post([FromBody] MaintenanceLogTypeDto newMaintenanceLogType)
        {
            try
            {
                var result = await _maintenanceLogTypeService.AddMaintenanceLogTypeAsync(newMaintenanceLogType);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Error adding maintenance log type");
            }
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<MaintenanceLogTypeDto>> Put([FromBody] MaintenanceLogTypeDto maintenanceLogType)
        {
            try
            {
                var result = await _maintenanceLogTypeService.UpdateMaintenanceLogTypeAsync(maintenanceLogType);
                return Ok(result);
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Error with input maintenance log type");
            }
            catch (Exception)
            {
                return BadRequest("Error updating maintenance log type");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _maintenanceLogTypeService.DeleteMaintenanceLogTypeAsync(id);
                return Ok();
            }
            catch (ArgumentNullException)
            {
                return NotFound($"Error finding maintenance log type {id} to delete");
            }
            catch (Exception)
            {
                return Conflict($"Error deleting maintenance log type {id}");
            }

        }

    }
}
