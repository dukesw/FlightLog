using DukeSoftware.FlightLog.ApplicationCore.Entities;

namespace DukeSoftware.FlightLog.ApplicationCore.Interfaces
{
    public interface IBatteryService
    {
        Battery EnterDischargeData(Battery battery, int mahUsed);
        
    }
}