using DukeSoftware.FlightLog.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DukeSoftware.FlightLog.ApplicationCore.Interfaces
{
    public interface IBatteryService
    {
        Task<List<Battery>> ListBatteriesAsync();
        Task<List<BatteryType>> ListBatteryTypesAsync();
        Task<Battery> GetBatteryByIdAsync(int id);
        Task<BatteryType> GetBatteryTypeByIdAsync(int id);
        Task<Battery> EnterNewBatteryAsync(Battery battery);
        Task<BatteryType> EnterNewBatteryTypeAsync(BatteryType batteryType);
        Task<Battery> UpdateBatteryAsync(Battery battery);
        Task<BatteryType> UpdateBatteryTypeAsync(BatteryType batteryType);
        Task DeleteBatteryAsync(int id);
        Task DeleteBatteryTypeAsync(int id);
        Task<Battery> EnterChargeDataAsync(Battery battery, DateTime chargeDate, ChargeType chargeType, int mahUsed);

    }
}