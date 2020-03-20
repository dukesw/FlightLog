using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
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
        public async Task<ActionResult> Get()
        {
            var flights = await _flightService.GetFlightsAsync();
            return Ok(flights.ToArray());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Flight>> GetById(long id)
        {
            try
            {
                var flight = await _flightService.GetFlightByIdAsync(id);
                return Ok(flight);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
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
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // TODO Fix this or create a better implemetnation with some rules for updating batteries
        [HttpPut]
        public async Task<ActionResult<Flight>> Put([FromBody] Flight flight)
        {
            try
            {
                var result = await _flightService.UpdateFlightAsync(flight);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // TODO Fix this method
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                await _flightService.DeleteFlightAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}