using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;

namespace DukeSoftware.FlightLog.ApplicationCore.Services
{
    public class ModelService : IModelService
    {   
        public ModelService(IModelRepository modelRepository)
        {
        }

        public Task<Model> AddModelAsync(Model model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteModelAsync(Model model)
        {
            throw new NotImplementedException();
        }

        public Task<Model> GetModelByIdAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Model>> ListModelsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Model> UpdateModelAsync(Model model)
        {
            throw new NotImplementedException();
        }
    }
}
