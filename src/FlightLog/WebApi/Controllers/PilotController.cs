using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using DukeSoftware.GuardClauses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("/api/pilots")]
    [ApiController]
    public class PilotController : ControllerBase
    {
        private IPilotService _pilotService;

        public PilotController(IPilotService pilotService)
        {
            Guard.AgainstNull(pilotService, "pilotService");
            this._pilotService = pilotService;
        }

        [HttpGet]
       // [Authorize(Roles = "flightlog-api.admin, flightlog-api.read")]
        public async Task<ActionResult> List()
        {
            var pilots = await _pilotService.GetPilotsAsync();
            return Ok(pilots.ToArray());
        }


    }
}
