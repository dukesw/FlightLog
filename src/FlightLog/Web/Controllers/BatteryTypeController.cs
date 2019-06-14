using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DukeSoftware.FlightLog.ApplicationCore.Entities;
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
        public async Task<ActionResult> List()
        {
            var batteryTypes = await _batteryService.ListBatteryTypesAsync();
            return Ok(batteryTypes.ToArray());
        }

        [HttpGet]
        public async Task<ActionResult> GetById(long id)
        {
            var batteryType = await _batteryService.GetBatteryTypeByIdAsync(id);
            return Ok(batteryType);
        }
    }
}
