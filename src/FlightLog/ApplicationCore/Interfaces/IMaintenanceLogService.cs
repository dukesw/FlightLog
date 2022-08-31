using DukeSoftware.FlightLog.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DukeSoftware.FlightLog.ApplicationCore.Interfaces
{
    public interface IMaintenanceLogService
    {
        Task<IList<MaintenanceLogDto>> GetMaintenanceLogsAsync(int accountId);
        Task<MaintenanceLogDto> GetMaintenanceLogByIdAsync(int accountId, int id);
        Task<MaintenanceLogDto> AddMaintenanceLogAsync(int accountId, MaintenanceLogDto maintenanceLog);
        Task<MaintenanceLogDto> UpdateMaintenanceLogAsync(int accountId, MaintenanceLogDto maintenanceLog);
        Task DeleteMaintenanceLogAsync(int accountId, int id);
    }
}
