using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    /// <summary>
    /// The BatteryController has some standard CRUD type methods in a REST style alongside some more "ProcessName" methods
    /// </summary>
    [Route("/api/models")]
    public class ModelController : BaseApiController
    {
        private readonly IModelService _modelService;

        public ModelController(IModelService modelService)
        {
            _modelService = modelService;
        }

        [HttpGet]
        public async Task<ActionResult> List()
        {
            var models = await _modelService.GetModelsAsync();
            return Ok(models.ToArray());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var model = await _modelService.GetModelByIdAsync(id);
                return Ok(model);
            }
            catch (ArgumentNullException)
            {
                return NotFound($"Error finding model {id}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Model>> Post([FromBody] Model newModel)
        {
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
        public async Task<ActionResult<Model>> Put([FromBody] Model model)
        {
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
        public async Task<ActionResult> Delete(int id)
        {
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
