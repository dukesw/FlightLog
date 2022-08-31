using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Exceptions;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using DukeSoftware.FlightLog.Shared.Dtos;
using DukeSoftware.GuardClauses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    /// <summary>
    /// The BatteryController has some standard CRUD type methods in a REST style alongside some more "ProcessName" methods
    /// </summary>
    [Route("/api/flighttags")]
    public class FlightTagController : BaseApiController
    {
        private readonly IFlightTagService _flightTagService;

        public FlightTagController(IFlightTagService flightTagService)
        {
            _flightTagService = flightTagService;
        }

        [HttpGet]
        [Authorize(Roles = "User, Admin")]
        // [Authorize]
        public async Task<ActionResult> List()
        {
            var flightTags = await _flightTagService.GetFlightTagsAsync();
            return Ok(flightTags.ToArray());
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var flightTag = await _flightTagService.GetFlightTagByIdAsync(id);
                return Ok(flightTag);
            }
            catch (ArgumentNullException)
            {
                return NotFound($"Error finding flight tag {id}");
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<FlightTagDto>> Post([FromBody] FlightTagDto flightTag)
        {
            try
            {
                var result = await _flightTagService.AddFlightTagAsync(flightTag);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Error adding flight tag");
            }
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<FlightTagDto>> Put([FromBody] FlightTagDto flightTag)
        {
            try
            {
                var result = await _flightTagService.UpdateFlightTagAsync(flightTag);
                return Ok(result);
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Error with input flight tag");
            }
            catch (Exception)
            {
                return BadRequest("Error updating flight tag");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _flightTagService.DeleteFlightTagAsync(id);
                return Ok();
            }
            catch (ArgumentNullException)
            {
                return NotFound($"Error finding flight tag {id} to delete");
            }
            catch (Exception)
            {
                return Conflict($"Error deleting flight tag {id}");
            }

        }

    }
}
