using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using DukeSoftware.GuardClauses;
using DukeSoftware.FlightLog.ApplicationCore.Entities;
using System.Threading.Tasks;

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
            _logger = logger ;
        }

        public async Task<List<Battery>> ListBatteriesAsync()
        {
            return await _batteryRepository.ListAllAsync();
        }

        public async Task<List<BatteryType>> ListBatteryTypesAsync()
        {
            return await _batteryTypeRepository.ListAllAsync();
        }

        public async Task<Battery> GetBatteryByIdAsync(long id)
        {
            Guard.AgainstNull(id, "id");
            var result = await _batteryRepository.GetByIdAsync(id);
            return result;
        }

        public async Task<BatteryType> GetBatteryTypeByIdAsync(long id)
        {
            Guard.AgainstNull(id, "id");
            var result = await _batteryTypeRepository.GetByIdAsync(id);
            return result;
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
            Guard.AgainstNullBattery(repoBattery, battery.Id, "repoBattery");

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

        public async Task<Battery> EnterNewBatteryAsync(Battery battery, BatteryType batteryType)
        {
            Guard.AgainstNull(battery, "battery");
            Guard.AgainstNull(batteryType, "batteryType");

            // If the type does not exist, add it
            var repoBatteryType = await _batteryTypeRepository.GetByIdAsync(batteryType.Id);
            if (repoBatteryType == null)
            {
                repoBatteryType = _batteryTypeRepository.Add(batteryType);
                _logger.LogInformation($"Added battery type, new Id = {repoBatteryType.Id}");
            }

            battery.BatteryType = batteryType;

            return await _batteryRepository.AddAsync(battery);
        }

        public async Task<BatteryType> EnterNewBatteryTypeAsync(BatteryType batteryType)
        {
            Guard.AgainstNull(batteryType, "batteryType");
            await _batteryTypeRepository.AddAsync(batteryType);
            _logger.LogInformation($"Added battery type, new Id = {batteryType.Id}");
            return batteryType;
        }

    }
}
