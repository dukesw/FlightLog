using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DukeSoftware.FlightLog.ApplicationCore.Interfaces
{
    public interface IModelStatusService
    {
        Task<IList<ModelStatusDto>> GetModelStatusesAsync();
        Task<IList<ModelStatusDto>> GetActiveModelStatusesAsync();

        Task<ModelStatusDto> GetModelStatusByIdAsync(int id);
        Task<ModelStatusDto> AddModelStatusAsync(ModelStatusDto model);
        Task<ModelStatusDto> UpdateModelStatusAsync(ModelStatusDto model);
        Task DeleteModelStatusAsync(int id);
    }
}
