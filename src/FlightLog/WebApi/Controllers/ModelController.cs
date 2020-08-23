using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    /// <summary>
    /// The BatteryController has some standard CRUD type methods in a REST style alongside some more "ProcessName" methods
    /// </summary>
    [Route("/api/{accountId}/models")]
    public class ModelController : BaseApiController
    {
        private readonly IModelService _modelService;

        public ModelController(IModelService modelService)
        {
            _modelService = modelService;
        }

        [HttpGet]
        [Authorize(Roles = "flightlog-api.admin, flightlog-api.read")]
        public async Task<ActionResult> List(int accountId)
        {
            if (!IsAccountIdOk(HttpContext, accountId))
            {
                return Forbid();
            }

            var models = await _modelService.GetModelsAsync(accountId);
            return Ok(models.ToArray());
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "flightlog-api.admin, flightlog-api.read")]
        public async Task<ActionResult> GetById(int accountId, int id)
        {
            if (!IsAccountIdOk(HttpContext, accountId))
            {
                return Forbid();
            }

            try
            {
                var model = await _modelService.GetModelByIdAsync(accountId, id);
                return Ok(model);
            }
            catch (ArgumentNullException)
            {
                return NotFound($"Error finding model {id}");
            }
        }

        [HttpPost]
        [Authorize(Roles = "flightlog-api.admin, flightlog-api.write")]
        public async Task<ActionResult<Model>> Post([FromBody] Model newModel)
        {
            if (!IsAccountIdOk(HttpContext, newModel.AccountId))
            {
                return Forbid();
            }

            try
            {
                var result = await _modelService.AddModelAsync(newModel);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Error adding model");
            }
        }

        // TODO Fix this or create a better implemetnation with some rules for updating batteries
        [HttpPut]
        [Authorize(Roles = "flightlog-api.admin, flightlog-api.write")]
        public async Task<ActionResult<Model>> Put([FromBody] Model model)
        {
            if (!IsAccountIdOk(HttpContext, model.AccountId))
            {
                return Forbid();
            }

            try
            {
                var result = await _modelService.UpdateModelAsync(model);
                return Ok(result);
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Error with input model");
            }
            catch (Exception)
            {
                return BadRequest("Error updating model");
            }
        }

        // TODO Fix this method
        [HttpDelete("{id}")]
        [Authorize(Roles = "flightlog-api.admin, flightlog-api.write")]
        public async Task<ActionResult> Delete(int accountId, int id)
        {
            if (!IsAccountIdOk(HttpContext, accountId))
            {
                return Forbid();
            }

            try
            {
                await _modelService.DeleteModelAsync(id);
                return Ok();
            }
            catch (ArgumentNullException)
            {
                return NotFound($"Error finding model {id} to delete");
            }
            catch (Exception)
            {
                return Conflict($"Error deleting model {id}");
            }

        }

    }
}
