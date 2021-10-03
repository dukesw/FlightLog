using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Exceptions;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using DukeSoftware.GuardClauses;
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
        [Authorize(Roles = "User, Admin")]
        // [Authorize]
        public async Task<ActionResult> List(int accountId)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                var models = await _modelService.GetModelsAsync(accountId);
                return Ok(models.ToArray());
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult> GetById(int accountId, int id)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                var model = await _modelService.GetModelByIdAsync(accountId, id);
                return Ok(model);
            }
            catch (ArgumentNullException)
            {
                return NotFound($"Error finding model {id}");
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
        }

        [HttpPost]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult<Model>> Post(int accountId, [FromBody] Model newModel)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                var result = await _modelService.AddModelAsync(accountId, newModel);
                return Ok(result);
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
            catch (Exception)
            {
                return BadRequest("Error adding model");
            }
        }

        [HttpPut]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult<Model>> Put(int accountId, [FromBody] Model model)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                var result = await _modelService.UpdateModelAsync(accountId, model);
                return Ok(result);
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Error with input model");
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
            catch (Exception)
            {
                return BadRequest("Error updating model");
            }
        }

        // TODO Fix this method
        [HttpDelete("{id}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult> Delete(int accountId, int id)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                await _modelService.DeleteModelAsync(accountId, id);
                return Ok();
            }
            catch (ArgumentNullException)
            {
                return NotFound($"Error finding model {id} to delete");
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
            catch (Exception)
            {
                return Conflict($"Error deleting model {id}");
            }

        }

    }
}
