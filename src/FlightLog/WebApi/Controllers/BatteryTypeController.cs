using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Exceptions;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers
{
    [Route("/api/batteryTypes")]
    public class BatteryTypeController : BaseApiController
    {
        private readonly IBatteryService _batteryService;

        public BatteryTypeController(IBatteryService batteryService)
        {
            _batteryService = batteryService;
        }

        [HttpGet]
        [Authorize(Roles = "flightlog-api.admin, flightlog-api.read")]
        public async Task<ActionResult> Get()
        {
            var batteryTypes = await _batteryService.ListBatteryTypesAsync();
            return Ok(batteryTypes.ToArray());
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "flightlog-api.admin, flightlog-api.read")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var batteryType = await _batteryService.GetBatteryTypeByIdAsync(id);
                return Ok(batteryType);
            } 
            catch(ArgumentNullException ex)
            {
                return NotFound($"Error finding battery type {id}");
            }
        }

        [HttpPost]
        [Authorize(Roles = "flightlog-api.admin, flightlog-api.write")]
        public async Task<ActionResult> AddNew([FromBody] BatteryType batteryType)
        {
            // Validate the input
            try
            {
                var result = await _batteryService.EnterNewBatteryTypeAsync(batteryType);
                return Ok(result);
            } 
            catch (Exception)
            {
                return BadRequest("Error adding battery type");
            }
        }

        [HttpPut]
        [Authorize(Roles = "flightlog-api.admin, flightlog-api.write")]
        public async Task<ActionResult> Update([FromBody] BatteryType batteryType)
        {
            try
            {
                var result = await _batteryService.UpdateBatteryTypeAsync(batteryType);
                return Ok(result);
            } 
            catch (ArgumentNullException)
            {
                return BadRequest("Error with input battery type");
            }
            catch(Exception)
            {
                return BadRequest("Error updating battery type");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "flightlog-api.admin, flightlog-api.write")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _batteryService.DeleteBatteryTypeAsync(id);
                return Ok();
            }
            catch (BatteryTypeNotFoundException)
            {
                return NotFound($"Error finding battery type {id} to delete");
            }
            catch (Exception)
            {
                return Conflict($"Error deleting battery type {id}");
            }
        }
    }   
}
    