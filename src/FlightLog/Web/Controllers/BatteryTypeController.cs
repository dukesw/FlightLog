using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Exceptions;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Web.Controllers
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
        public async Task<ActionResult> Get()
        {
            var batteryTypes = await _batteryService.ListBatteryTypesAsync();
            return Ok(batteryTypes.ToArray());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(long id)
        {
            try
            {
                var batteryType = await _batteryService.GetBatteryTypeByIdAsync(id);
                return Ok(batteryType);
            } 
            catch(ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddNew([FromBody] BatteryType batteryType)
        {
            // Validate the input
            try
            {
                var result = await _batteryService.EnterNewBatteryTypeAsync(batteryType);
                if (result == null)
                {
                    return NotFound(batteryType);
                }
                return Ok(result);
            } 
            catch (BatteryTypeNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] BatteryType batteryType)
        {
            try
            {
                var result = await _batteryService.UpdateBatteryTypeAsync(batteryType);
                if (result == null)
                {
                    return NotFound(batteryType);
                }
                return Ok(result);
            } 
            catch (BatteryTypeNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                await _batteryService.DeleteBatteryTypeAsync(id);
                return Ok();
            }
            catch (ArgumentNullException)
            {
                return NotFound(id);
            }
        }
    }   
}
    