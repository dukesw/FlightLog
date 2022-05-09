using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.Shared.Dtos;

namespace DukeSoftware.FlightLog.ApplicationCore.Interfaces
{
    public interface IAccountService
    {
        Task<IList<AccountDto>> GetAccountsAsync();
      
        Task<AccountDto> GetAccountByIdAsync(int id);
        Task<AccountDto> AddAccountAsync(AccountDto account);
        Task<AccountDto> UpdateAccountAsync(AccountDto account);
        Task DeleteAccountAsync(int id); // TODO Maybe, the deletes should return bool? Or do they just throw
    }
}
