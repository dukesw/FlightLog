using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DukeSoftware.FlightLog.ApplicationCore.Entities;
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
        //private readonly IBatteryRepository _batteryRepository;

        public BatteryController(IBatteryService batteryService)
        {
            _batteryService = batteryService;
         //   _batteryRepository = batteryRepository;
        }

        [HttpGet]
        public async Task<ActionResult> List()
        {
            var batteries = await _batteryService.ListBatteriesAsync();
            return Ok(batteries.ToArray());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(long id)
        {
            try
            {
                var battery = await _batteryService.GetBatteryByIdAsync(id);
                return Ok(battery);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Battery>> Post(Battery newBattery)
        {
            try
            {
                var result = await _batteryService.EnterNewBatteryAsync(newBattery);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // TODO Fix this or create a better implemetnation with some rules for updating batteries
        [HttpPut]
        public async Task<ActionResult<Battery>> Put(Battery battery)
        {
            try
            {
                var result = await _batteryService.UpdateBatteryAsync(battery);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // TODO Fix this method
        [HttpDelete]
        public async Task<ActionResult> Delete(Battery battery)
        {
            try
            {
                await _batteryService.DeleteBatteryAsync(battery.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        //[HttpPost("/new")]
        //public ActionResult<Battery> EnterNewBattery(Battery battery, BatteryType batteryType)
        //{
        //    try
        //    {
        //        var result = _batteryService.EnterNewBatteryAsync(battery, batteryType);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex); 
        //    }
        //}
    }
}
