using DukeSoftware.FlightLog.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DukeSoftware.FlightLog.ApplicationCore.Interfaces
{
    public interface IBatteryService
    {
        Task<List<Battery>> ListBatteriesAsync(int accountId);
        Task<List<BatteryType>> ListBatteryTypesAsync(int accountId);
        Task<Battery> GetBatteryByIdAsync(int accountId, int id);
        Task<BatteryType> GetBatteryTypeByIdAsync(int accountId, int id);
        Task<Battery> EnterNewBatteryAsync(int accountId, Battery battery);
        Task<BatteryType> EnterNewBatteryTypeAsync(int accountId, BatteryType batteryType);
        Task<Battery> UpdateBatteryAsync(int accountId, Battery battery);
        Task<BatteryType> UpdateBatteryTypeAsync(int accountId, BatteryType batteryType);
        Task DeleteBatteryAsync(int accountId, int id);
        Task DeleteBatteryTypeAsync(int accountId, int id);
        Task<Battery> EnterChargeDataAsync(int accountId, Battery battery, DateTime chargeDate, ChargeType chargeType, int mahUsed);

    }
}