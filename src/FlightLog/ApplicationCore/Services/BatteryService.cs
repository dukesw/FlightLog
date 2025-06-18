using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using DukeSoftware.GuardClauses;
using DukeSoftware.FlightLog.ApplicationCore.Entities;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DukeSoftware.FlightLog.ApplicationCore.Specifications;
using System.Linq;

namespace DukeSoftware.FlightLog.ApplicationCore.Services
{
    // The intention is that this function will look after any functions related to battey management. 
    // For example the mode that a battery is currently in (storage, charged, depleted), and when charged/flown how many mah were put back into it. 
    public class BatteryService : IBatteryService
    {
        private readonly IBatteryRepository _batteryRepository;
        private readonly IBatteryTypeRepository _batteryTypeRepository;
        private readonly IAppLogger<BatteryService> _logger;

        public BatteryService(
            IBatteryRepository batteryRepository,
            IBatteryTypeRepository batteryTypeRepository,
            IAppLogger<BatteryService> logger)
        {
            Guard.AgainstNull(batteryRepository, "batteryRepository");
            Guard.AgainstNull(batteryTypeRepository, "batteryTypeRepository");
            Guard.AgainstNull(logger, "logger");

            _batteryRepository = batteryRepository;
            _batteryTypeRepository = batteryTypeRepository;
            _logger = logger;
        }

        public async Task<List<Battery>> ListBatteriesAsync(int accountId)
        {
            var spec = new GetBatteriesByAccount(accountId);
            return await _batteryRepository.GetBySpecAsync(spec);
        }

        public async Task<List<BatteryType>> ListBatteryTypesAsync(int accountId)
        {
            var spec = new GetBatteryTypesByAccount(accountId);
            return await _batteryTypeRepository.GetBySpecAsync(spec);
        }

        public async Task<Battery> GetBatteryByIdAsync(int accountId, int id)
        {
            // TODO add an async version of get by spec??
            var result = await _batteryRepository.GetBySpecAsync(new GetBatteryByAccountAndIdWithIncludes(accountId, id));
            Guard.AgainstNull(result.FirstOrDefault(), "result");
            return result.FirstOrDefault();
        }

        public async Task<BatteryType> GetBatteryTypeByIdAsync(int accountId, int id)
        {
            var spec = new GetBatteryTypesByAccountAndIdWithIncludes(accountId, id); 
            var result = await _batteryTypeRepository.GetBySpecAsync(spec);
            Guard.AgainstNull(result.FirstOrDefault(), "result");
            return result.FirstOrDefault();
        }

        public async Task<Battery> EnterNewBatteryAsync(int accountId, Battery battery)
        {
            Guard.AgainstNull(battery, "battery");
            Guard.AgainstAccountNumberMismatch(accountId, battery.AccountId, "accountId", "battery.AccountId");
            //Guard.AgainstNull(batteryType, "batteryType");

            // If the type does not exist, add it
            if (battery.BatteryType != null)
            {
                var repoBatteryType = await _batteryTypeRepository.GetByIdAsync(battery.BatteryType.Id);
                battery.BatteryType = repoBatteryType;
            }
            try
            {
                battery = await _batteryRepository.AddAsync(battery);
                _logger.LogInformation($"Added battery, new Id = {battery.Id}");
                return battery;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error adding battery: {battery}.");
                return null;
            }
        }

        public async Task<BatteryType> EnterNewBatteryTypeAsync(int accountId, BatteryType batteryType)
        {
            Guard.AgainstNull(batteryType, "batteryType");
            Guard.AgainstAccountNumberMismatch(accountId, batteryType.AccountId, "accountId", "batteryType.AccountId");

            try
            {
                await _batteryTypeRepository.AddAsync(batteryType);
                _logger.LogInformation($"Added battery type, new Id = {batteryType.Id}");
                return batteryType;
            } 
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error adding battery type: {batteryType}.");
                return null;
            }
        }

        public async Task<Battery> UpdateBatteryAsync(int accountId, Battery battery)
        {
            Guard.AgainstNull(battery, "battery");
            Guard.AgainstAccountNumberMismatch(accountId, battery.AccountId, "accountId", "battery.AccountId");

            var result = await _batteryRepository.UpdateAsync(battery); // Use batteryex
            if (result != null)
            {
                _logger.LogInformation($"Updated battery, Id = {battery.Id}");
            } 
            else
            {
                _logger.LogWarning($"Could not update battery, Id = {battery.Id}");
            }
            return result;
        }

        public async Task<BatteryType> UpdateBatteryTypeAsync(int accountId, BatteryType batteryType)
        {
            Guard.AgainstNull(batteryType, "batteryType");
            Guard.AgainstAccountNumberMismatch(accountId, batteryType.AccountId, "accountId", "batteryType.AccountId");

            var result = await _batteryTypeRepository.UpdateAsync(batteryType);
            if (result != null)
            {
                _logger.LogInformation($"Updated battery type, Id = {batteryType.Id}");
            }
            else
            {
                _logger.LogWarning($"Could not update battery type, Id = {batteryType.Id}");
            }
            return result;
        }

        public async Task DeleteBatteryAsync(int accountId, int id)
        {
            var batteryToDelete = _batteryRepository.GetById(id);
            Guard.AgainstBatteryNotFound(batteryToDelete, id, "batteryToDelete");
            Guard.AgainstAccountNumberMismatch(accountId, batteryToDelete.AccountId, "accountId", "batteryToDelete.AccountId");
            await _batteryRepository.DeleteAsync(batteryToDelete);
        }

        public async Task DeleteBatteryTypeAsync(int accountId, int id)
        {
            var batteryTypeToDelete = _batteryTypeRepository.GetById(id);
            Guard.AgainstBatteryTypeNotFound(batteryTypeToDelete, id, "batteryTypeToDelete");
            Guard.AgainstAccountNumberMismatch(accountId, batteryTypeToDelete.AccountId, "accountId", "batteryTypeToDelete.AccountId");
            await _batteryTypeRepository.DeleteAsync(batteryTypeToDelete);
        }
    }
}
