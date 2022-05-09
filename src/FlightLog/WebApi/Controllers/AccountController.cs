using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using DukeSoftware.FlightLog.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountController: BaseApiController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> List()
        {
            var accounts = await _accountService.GetAccountsAsync();
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var account = await _accountService.GetAccountByIdAsync(id);
                return Ok(account);
            }
            catch (ArgumentNullException)
            {
                return NotFound($"Error finding account {id}");
            }
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<AccountDto>> Post([FromBody] AccountDto newAccount)
        {
            try
            {
                var result = await _accountService.AddAccountAsync(newAccount);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Error adding account");
            }
        }


        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<AccountDto>> Put([FromBody] AccountDto account)
        {
            try
            {
                var result = await _accountService.UpdateAccountAsync(account);
                return Ok(result);
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Error with input account");
            }
            catch (Exception)
            {
                return BadRequest("Error updating account");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _accountService.DeleteAccountAsync(id);
                return Ok();
            }
            catch (ArgumentNullException)
            {
                return NotFound($"Error finding account {id} to delete");
            }
            catch (Exception)
            {
                return Conflict($"Error deleting account {id}");
            }

        }

    }
}
