using DukeSoftware.FlightLog.ApplicationCore.Entities;

namespace DukeSoftware.FlightLog.ApplicationCore.Interfaces
{
    public interface IMaintenanceLogTypeRepository : IRepository<MaintenanceLogType>, IAsyncRepository<MaintenanceLogType>
    {
    }
}