using AutoMapper;
using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Exceptions;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using DukeSoftware.FlightLog.Shared.Dtos;
using DukeSoftware.GuardClauses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("/api/{accountId}/pilots")]
    [ApiController]
    public class PilotController : BaseApiController
    {
        private IPilotService _pilotService;
        private readonly IMapper _mapper;

        public PilotController(IPilotService pilotService, IMapper mapper)
        {
            Guard.AgainstNull(pilotService, "pilotService");
            this._pilotService = pilotService;
            this._mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult> List(int accountId)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                var pilots = await _pilotService.GetPilotsAsync(accountId);
                var pilotDtos = _mapper.Map<IList<Pilot>, IList<PilotDto>>(pilots).ToArray();
                return Ok(pilotDtos.ToArray());
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
        }
    }
}
