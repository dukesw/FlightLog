using DukeSoftware.FlightLog.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DukeSoftware.FlightLog.ApplicationCore.Interfaces
{
    interface IModelService
    {
        // TODO Work on the ModelService (and interface) next... 
        Task<List<Model>> ListModelsAsync();
        Task<Model> GetModelByIdAsync();
        Task<Model> AddModelAsync(Model model);
        Task<Model> UpdateModelAsync(Model model);
        Task DeleteModelAsync(Model model);
    }
}
