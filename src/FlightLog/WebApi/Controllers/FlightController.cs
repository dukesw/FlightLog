using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DukeSoftware.FlightLog.ApplicationCore.Dtos;
using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/flights")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _flightService;

        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpGet]
        //[Authorize]
        public async Task<ActionResult> Get()
        {
            var flights = await _flightService.GetFlightsAsync();
            return Ok(flights);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Flight>> GetById(int id)
        {
            try
            {
                var flight = await _flightService.GetFlightByIdAsync(id);
                return Ok(flight);
            }
            catch (ArgumentNullException)
            {
                return NotFound($"Error finding flight {id}");
            }
        }

        [HttpGet("model/{modelId}")]
        public async Task<ActionResult<List<FlightDto>>> GetByModelId(int modelId)
        {
            try
            {
                var flights = await _flightService.GetFlightsByModelAsync(modelId);
                return Ok(flights);
            }
            catch (ArgumentNullException)
            {
                return NotFound($"Error finding flights for model {modelId}");
            }
        }

        [HttpGet("summary/{modelId}")]
        public async Task<ActionResult<FlightSummaryDto>> GetSummaryByModelId(int modelId)
        {
            try
            {
                var flights = await _flightService.GetFlightSummaryByModelAsync(modelId);
                return Ok(flights);
            }
            catch (ArgumentNullException)
            {
                return NotFound($"Error finding flights for model {modelId}");
            }
        }


        [HttpPost]
        public async Task<ActionResult<Flight>> Post([FromBody] Flight newFlight)
        {
            try
            {
                var result = await _flightService.AddFlightAsync(newFlight);
                return Ok(result);
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Error with input flight");
            }
            catch (Exception)
            {
                return BadRequest("Error adding flight");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Flight>> Put([FromBody] Flight flight)
        {
            try
            {
                var result = await _flightService.UpdateFlightAsync(flight);
                return Ok(result);
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Error with input flight");
            }
            catch (Exception)
            {
                return BadRequest("Error updating flight");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _flightService.DeleteFlightAsync(id);
                return Ok();
            }
            catch (ArgumentNullException)
            {
                return NotFound($"Error finding flight {id} to delete");
            }
            catch (Exception)
            {
                // Not expecting this to trigger as any flight can be deleted even if it has a model, location etc... 
                return Conflict("Error deleting flight {id}");  
            }
        }
    }
}