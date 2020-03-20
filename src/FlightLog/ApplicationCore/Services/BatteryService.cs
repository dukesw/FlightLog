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
        private readonly IBatteryChargeRepository _batteryChargeRepository;
        private readonly IAppLogger<BatteryService> _logger;

        public BatteryService(
            IBatteryRepository batteryRepository,
            IBatteryTypeRepository batteryTypeRepository,
            IBatteryChargeRepository batteryChargeRepository,
            IAppLogger<BatteryService> logger)
        {
            Guard.AgainstNull(batteryRepository, "batteryRepository");
            Guard.AgainstNull(batteryTypeRepository, "batteryTypeRepository");
            Guard.AgainstNull(batteryChargeRepository, "batteryChargeRepository");
            Guard.AgainstNull(logger, "logger");

            _batteryRepository = batteryRepository;
            _batteryTypeRepository = batteryTypeRepository;
            _batteryChargeRepository = batteryChargeRepository;
            _logger = logger;
        }

        public async Task<List<Battery>> ListBatteriesAsync()
        {
            var includes = new List<Expression<Func<Battery, object>>>();
            includes.Add(b => b.BatteryType);
            return await _batteryRepository.ListAllAsync(includes);
        }

        public async Task<List<BatteryType>> ListBatteryTypesAsync()
        {
            return await _batteryTypeRepository.ListAllAsync();
        }

        public async Task<Battery> GetBatteryByIdAsync(long id)
        {
            Guard.AgainstNull(id, "id");
            // TODO add an async version of get by spec??
            var result = await _batteryRepository.ListAsync(new GetBatteryWithBatteryTypeById(id));
            return result.FirstOrDefault();
        }

        public async Task<BatteryType> GetBatteryTypeByIdAsync(long id)
        {
            Guard.AgainstNull(id, "id");
            var result = await _batteryTypeRepository.GetByIdAsync(id);
            return result;
        }

        public async Task<Battery> EnterNewBatteryAsync(Battery battery)
        {
            Guard.AgainstNull(battery, "battery");
            //Guard.AgainstNull(batteryType, "batteryType");

            try
            {
                battery.BatteryType = await _batteryTypeRepository.GetByIdAsync(battery.BatteryTypeId);    // Ensures the battery type is attached
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

        public async Task<BatteryType> EnterNewBatteryTypeAsync(BatteryType batteryType)
        {
            Guard.AgainstNull(batteryType, "batteryType");
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

        public async Task<Battery> UpdateBatteryAsync(Battery battery)
        {
            Guard.AgainstNull(battery, "battery");
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

        public async Task<BatteryType> UpdateBatteryTypeAsync(BatteryType batteryType)
        {
            Guard.AgainstNull(batteryType, "batteryType");
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

        public async Task DeleteBatteryAsync(long id)
        {
            var batteryToDelete = _batteryRepository.GetById(id);
            Guard.AgainstBatteryNotFound(batteryToDelete, id, "batteryToDelete");
            await _batteryRepository.DeleteAsync(batteryToDelete);
        }

        public async Task DeleteBatteryTypeAsync(long id)
        {
            var batteryTypeToDelete = _batteryTypeRepository.GetById(id);
            Guard.AgainstBatteryTypeNotFound(batteryTypeToDelete, id, "batteryTypeToDelete");
            await _batteryTypeRepository.DeleteAsync(batteryTypeToDelete);
        }

        public async Task<Battery> EnterChargeDataAsync(Battery battery, DateTime chargeDate, ChargeType chargeType, int mahUsed)
        {
            // Seems like we need a "discharge" object or event...
            // Perhaps this could be charge data... ??? not discharge. Then idea is that when you charge it, you know how much was added. Although if you put into storage mode that will not work... 
            // Think about this based on the process used... 
            // Charge, discharge, storage, repeat... 

            Guard.AgainstNull(battery, "battery");
            Guard.AgainstNull(chargeDate, "chargeDate");

            // Make sure the battery exists
            var repoBattery = await _batteryRepository.GetByIdAsync(battery.Id);
            Guard.AgainstNull(repoBattery, "repoBattery");

            var batteryCharge = new BatteryCharge
            {
                ChargedOn = chargeDate,
                Type = chargeType,
                Mah = mahUsed,
                Battery = battery
            };

            await _batteryChargeRepository.AddAsync(batteryCharge);
            _logger.LogInformation($"Battery charge data saved, new Id = {batteryCharge.Id}");

            return await _batteryRepository.GetByIdAsync(battery.Id);
        }
    }
}
