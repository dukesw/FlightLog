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
        Task<Battery> EnterChargeDataAsync(Battery battery, DateTime chargeDate, ChargeType chargeType, int mahUsed);
        Task<Battery> EnterNewBatteryAsync(Battery battery, BatteryType batteryType);
    }
}