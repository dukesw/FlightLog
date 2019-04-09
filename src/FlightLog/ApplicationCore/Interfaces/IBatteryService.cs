using DukeSoftware.FlightLog.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DukeSoftware.FlightLog.ApplicationCore.Interfaces
{
    public interface IBatteryService
    {
        Task<List<BatteryType>> ListBatteryTypesAsync();
        Task<List<Battery>> ListBatteriesAsync();
        Task<Battery> GetBatteryByIdAsync(long id);
        Task<BatteryType> GetBatteryTypeByIdAsync(long id);
        Task<Battery> EnterChargeDataAsync(Battery battery, DateTime chargeDate, ChargeType chargeType, int mahUsed);
        Task<Battery> EnterNewBatteryAsync(Battery battery, BatteryType batteryType);
        Task<BatteryType> EnterNewBatteryTypeAsync(BatteryType batteryType);
    }
}