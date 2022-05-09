using AutoMapper;
using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using DukeSoftware.FlightLog.ApplicationCore.Specifications;
using DukeSoftware.FlightLog.Shared.Dtos;
using DukeSoftware.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DukeSoftware.FlightLog.ApplicationCore.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAppLogger<AccountService> _logger;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository accountRepository, IAppLogger<AccountService> logger, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _logger = logger;
            _mapper = mapper;
    }

        public async Task<AccountDto> AddAccountAsync(AccountDto account)
        {
            Guard.AgainstNull(account, "account");
            var accountEntity = _mapper.Map<AccountDto, Account>(account);

            try
            {
                await _accountRepository.AddAsync(accountEntity);
                _logger.LogInformation($"Added account, new Id = {accountEntity.Id}");
                return await GetAccountByIdAsync(accountEntity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error adding account: {account}.");
                return null;
            };
        }

        public async Task DeleteAccountAsync(int id)
        {
            try
            {
                var accountToDelete = _accountRepository.GetById(id);
                Guard.AgainstNull(accountToDelete, "accountToDelete");
                
                await _accountRepository.DeleteAsync(accountToDelete);
                _logger.LogInformation($"Deleted account with Id: {id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting account with Id: {id}");
                throw;
            }
        }

        public async Task<AccountDto> GetAccountByIdAsync(int id)
        {
            var spec = new GetAccountById(id);
            var result = await _accountRepository.GetBySpecAsync(spec);
            return _mapper.Map<Account, AccountDto>(result.FirstOrDefault());
        }

        public async Task<IList<AccountDto>> GetAccountsAsync()
        {
            var result = await _accountRepository.GetAllAsync();
            return _mapper.Map<IList<Account>, IList<AccountDto>>(result);
        }

        public async Task<AccountDto> UpdateAccountAsync(AccountDto account)
        {
            Guard.AgainstNull(account, "account");
           
            var accountEntity = _mapper.Map<AccountDto, Account>(account);

            var result = await _accountRepository.UpdateAsync(accountEntity);
            if (result != null)
            {
                _logger.LogInformation($"Updated account, Id = {accountEntity.Id}");
            }
            else
            {
                _logger.LogWarning($"Could not update account, Id = {accountEntity.Id}");
            }
            return await GetAccountByIdAsync(accountEntity.Id);
        }
    }
}
