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
    [Route("/api/modelstatuses")]
    public class ModelStatusController : BaseApiController
    {
        private readonly IModelStatusService _modelStatusService;

        public ModelStatusController(IModelStatusService modelStatusService)
        {
            _modelStatusService = modelStatusService;
        }

        [HttpGet]
        [Authorize(Roles = "User, Admin")]
        // [Authorize]
        public async Task<ActionResult> List()
        {
            var modelStatuses = await _modelStatusService.GetModelStatusesAsync();
            return Ok(modelStatuses.ToArray());
        }

        [HttpGet("active")]
        [Authorize(Roles = "User, Admin")]
        // [Authorize]
        public async Task<ActionResult> ListActive()
        {
            var modelStatuses = await _modelStatusService.GetActiveModelStatusesAsync();
            return Ok(modelStatuses.ToArray());
            
        }


        [HttpGet("{id}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var model = await _modelStatusService.GetModelStatusByIdAsync(id);
                return Ok(model);
            }
            catch (ArgumentNullException)
            {
                return NotFound($"Error finding model status {id}");
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
        }

        [HttpPost]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult<ModelDto>> Post([FromBody] ModelStatusDto newModelStatus)
        {
            try
            {
                var result = await _modelStatusService.AddModelStatusAsync(newModelStatus);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Error adding model status");
            }
        }

        [HttpPut]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult<ModelDto>> Put([FromBody] ModelStatusDto modelStatus)
        {
            try
            {
                var result = await _modelStatusService.UpdateModelStatusAsync(modelStatus);
                return Ok(result);
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Error with input model status");
            }
            catch (Exception)
            {
                return BadRequest("Error updating model status");
            }
        }

        // TODO Fix this method
        [HttpDelete("{id}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _modelStatusService.DeleteModelStatusAsync(id);
                return Ok();
            }
            catch (ArgumentNullException)
            {
                return NotFound($"Error finding model status {id} to delete");
            }
            catch (Exception)
            {
                return Conflict($"Error deleting model status {id}");
            }

        }

    }
}
