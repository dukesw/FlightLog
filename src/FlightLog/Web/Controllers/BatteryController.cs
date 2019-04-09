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

        // Removed as batteries should be added through the newaddition method 
        //[HttpPost]
        //public ActionResult<Battery> Post(Battery newBattery)
        //{
        //    try
        //    {
        //        var result = _batteryRepository.Add(newBattery);
        //        return Ok(result);
        //    } 
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex);
        //    }
        //}
        
        // TODO Fix this or create a better implemetnation with some rules for updating batteries
        //[HttpPut]
        //public ActionResult<Battery> Put(Battery battery)
        //{
        //    try
        //    {
        //        var result = _batteryRepository.Update(battery);
        //        return Ok(result);
        //    } 
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex);
        //    }
        //}

        // TODO Fix this method
        //[HttpDelete]
        //public ActionResult Delete(Battery battery)
        //{
        //    try
        //    {
        //        _batteryRepository.Delete(battery);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex);
        //    }

        //}

        [HttpPost("/new")]
        public ActionResult<Battery> EnterNewBattery(Battery battery, BatteryType batteryType)
        {
            try
            {
                var result = _batteryService.EnterNewBatteryAsync(battery, batteryType);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex); 
            }
        }
    }
}
