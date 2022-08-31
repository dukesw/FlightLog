using DukeSoftware.FlightLog.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DukeSoftware.FlightLog.ApplicationCore.Interfaces
{
    public interface IMaintenanceLogTypeService
    {
        Task<IList<MaintenanceLogTypeDto>> GetMaintenanceLogTypesAsync();
        Task<MaintenanceLogTypeDto> GetMaintenanceLogTypeByIdAsync(int id);
        Task<MaintenanceLogTypeDto> AddMaintenanceLogTypeAsync(MaintenanceLogTypeDto maintenanceLogType);
        Task<MaintenanceLogTypeDto> UpdateMaintenanceLogTypeAsync(MaintenanceLogTypeDto maintenanceLogType);
        Task DeleteMaintenanceLogTypeAsync(int id);
    }
}
