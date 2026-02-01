using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Exceptions;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using DukeSoftware.FlightLog.ApplicationCore.Services;
using DukeSoftware.FlightLog.Shared.Dtos;
using DukeSoftware.GuardClauses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                var models = await _modelService.GetModelsSortedBySortOrderAsync(accountId);
                return Ok(models.ToArray());
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
        }

        [HttpGet("count")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult> GetCount(int accountId)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                var modelCount = await _modelService.GetModelsCountsAsync(accountId);
                return Ok(modelCount);
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return BadRequest("Error getting model count: " + ex.ToString());
            }
        }

        [HttpGet("skip/{skip}/take/{take}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult> GetByPage(int accountId, int skip, int take)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                var models = await _modelService.GetModelsByPageAsync(accountId, skip, take);
                return Ok(models);
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
        }

        [HttpGet("sortby/{sortBy}/desc/{isDescending}/skip/{skip}/take/{take}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult> GetByPageSorted(int accountId, string sortBy, bool isDescending, int skip, int take)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                var models = await _modelService.GetModelsByPageSortedAsync(accountId, sortBy, isDescending, skip, take);
                return Ok(models);
            }
            catch (AccountConflictException)
            {
                return Forbid();
            }
        }

        [HttpGet("active")]
        [Authorize(Roles = "User, Admin")]
        // [Authorize]
        public async Task<ActionResult> ListActive(int accountId)
        {
            try
            {
                Guard.AgainstAccountNumberMismatch(GetAccountIdClaim(), accountId.ToString(), "userClaim.accountId", "accountId");
                var models = await _modelService.GetModelsByIsActiveAsync(accountId, true);
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
        public async Task<ActionResult<ModelDto>> Post(int accountId, [FromBody] ModelDto newModel)
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
        public async Task<ActionResult<ModelDto>> Put(int accountId, [FromBody] ModelDto model)
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
