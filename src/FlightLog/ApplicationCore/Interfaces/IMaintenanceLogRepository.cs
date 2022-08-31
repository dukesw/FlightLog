using DukeSoftware.FlightLog.ApplicationCore.Entities;

namespace DukeSoftware.FlightLog.ApplicationCore.Interfaces
{
    public interface IMaintenanceLogRepository : IRepository<MaintenanceLog>, IAsyncRepository<MaintenanceLog>
    {
    }
}