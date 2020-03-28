using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Exceptions;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers { 
    /// <summary>
    /// The BatteryController has some standard CRUD type methods in a REST style alongside some more "ProcessName" methods
    /// </summary>
    [Route("/api/batteries")]
    public class BatteryController : BaseApiController
    {
        private readonly IBatteryService _batteryService;

        public BatteryController(IBatteryService batteryService)
        {
            _batteryService = batteryService;
        }

        [HttpGet]
        public async Task<ActionResult> List()
        {
            var batteries = await _batteryService.ListBatteriesAsync();
            return Ok(batteries.ToArray());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var battery = await _batteryService.GetBatteryByIdAsync(id);
                return Ok(battery);
            }
            catch (ArgumentNullException)
            {
                return NotFound($"Error finding battery {id}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Battery>> Post([FromBody] Battery newBattery)
        {
            try
            {
                var result = await _batteryService.EnterNewBatteryAsync(newBattery);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Error adding battery");
            }
        }

        // TODO Fix this or create a better implemetnation with some rules for updating batteries
        [HttpPut]
        public async Task<ActionResult<Battery>> Put([FromBody] Battery battery)
        {
            try
            {
                var result = await _batteryService.UpdateBatteryAsync(battery);
                return Ok(result);
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Error with input battery");
            }
            catch (Exception)
            {
                return BadRequest($"Error updating battery");
            }
        }

        // TODO Fix this method
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _batteryService.DeleteBatteryAsync(id);
                return Ok();
            }
            catch (BatteryNotFoundException)
            {
                return NotFound($"Error finding battery {id} to delete");
            }
            catch (Exception)
            {
                return Conflict($"Error deleting battery {id}");
            }

        }
    }
}
