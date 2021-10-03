using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DukeSoftware.FlightLog.ApplicationCore.Exceptions;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using DukeSoftware.GuardClauses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("/api/{accountId}/pilots")]
    [ApiController]
    public class PilotController : BaseApiController
    {
        private IPilotService _pilotService;

        public PilotController(IPilotService pilotService)
        {
            Guard.AgainstNull(pilotService, "pilotService");
            this._pilotService = pilotService;
        }

        [HttpGet]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult> List(int accountId)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                var pilots = await _pilotService.GetPilotsAsync(accountId);
                return Ok(pilots.ToArray());
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
        }
    }
}
