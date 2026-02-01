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
        Task<IList<ModelDto>> GetModelsAsync(int accountId);
        Task<IList<ModelDto>> GetModelsSortedBySortOrderAsync(int accountId);
        Task<int> GetModelsCountsAsync(int accountId);
        Task<IList<ModelDto>> GetModelsByPageAsync(int accountId, int skip, int take);
        Task<IList<ModelDto>> GetModelsByPageSortedAsync(int accountId, string sortBy, bool isDescending, int skip, int take); 
        Task<IList<ModelDto>> GetModelsByIsActiveAsync(int accountId, bool isActive);
        Task<ModelDto> GetModelByIdAsync(int accountId, int id);
        Task<ModelDto> AddModelAsync(int accountId, ModelDto model);
        Task<ModelDto> UpdateModelAsync(int accountId, ModelDto model);
        Task DeleteModelAsync(int accountId, int id);
    }
}
