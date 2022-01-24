using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DukeSoftware.FlightLog.ApplicationCore.Interfaces
{
    public interface IModelService
    {
        // TODO Work on the ModelService (and interface) next... 
        Task<IList<ModelDto>> GetModelsAsync(int accountId);
        Task<IList<ModelDto>> GetModelsByIsActiveAsync(int accountId, bool isActive);

        Task<ModelDto> GetModelByIdAsync(int accountId, int id);
        Task<ModelDto> AddModelAsync(int accountId, ModelDto model);
        Task<ModelDto> UpdateModelAsync(int accountId, ModelDto model);
        Task DeleteModelAsync(int accountId, int id);
    }
}
