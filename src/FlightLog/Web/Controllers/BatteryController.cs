using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class BatteryController : BaseApiController
    {
        private readonly IBatteryService _batteryService;
        private readonly IBatteryRepository _batteryRepository;

        public BatteryController(IBatteryService batteryService, IBatteryRepository batteryRepository)
        {
            _batteryService = batteryService;
            _batteryRepository = batteryRepository;
        }

        [HttpGet]
        public async Task<ActionResult> List()
        {
            var batteries = await _batteryRepository.ListAllAsync();
            return Ok(batteries.ToArray());
        }

        [HttpPost]
        public ActionResult<Battery> Post(Battery newBattery)
        {
            try
            {
                var result = _batteryRepository.Add(newBattery);
                return Ok(result);
            } 
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public ActionResult<Battery> Put(Battery battery)
        {
            try
            {
                var result = _batteryRepository.Update(battery);
                return Ok(result);
            } 
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public ActionResult Delete(Battery battery)
        {
            try
            {
                _batteryRepository.Delete(battery);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpPost]
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
