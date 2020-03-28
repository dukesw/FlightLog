using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using DukeSoftware.FlightLog.ApplicationCore.Specifications;
using DukeSoftware.GuardClauses;

namespace DukeSoftware.FlightLog.ApplicationCore.Services
{
    public class ModelService : IModelService
    {
        private readonly IModelRepository _modelRepository;
        private readonly IAppLogger<ModelService> _logger;
        public ModelService(IModelRepository modelRepository, IAppLogger<ModelService> logger)
        {
            Guard.AgainstNull(modelRepository, "modelRepository");
            Guard.AgainstNull(logger, "logger");

            this._modelRepository = modelRepository;
            this._logger = logger;
        }

        public async Task<Model> AddModelAsync(Model model)
        {
            Guard.AgainstNull(model, "model");
            try
            {
                await _modelRepository.AddAsync(model);
                _logger.LogInformation($"Added model, new Id = {model.Id}");
                return model;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error adding model: {model}.");
                return null;
            }
        }

        public async Task DeleteModelAsync(int id)
        {
            try
            {
                var modelToDelete = _modelRepository.GetById(id);
                Guard.AgainstNull(modelToDelete, "modelToDelete");
                await _modelRepository.DeleteAsync(modelToDelete);
                _logger.LogInformation($"Deleted model with Id: {id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting model with Id: {id}");
                throw;
            }
        }

        public async Task<Model> GetModelByIdAsync(int id)
        {
            var spec = new GetModelByIdWithIncludes(id);
            var result = await _modelRepository.GetBySpecAsync(spec);
            Guard.AgainstNull(result.FirstOrDefault(), "result");
            return result.FirstOrDefault();
        }

        public async Task<List<Model>> GetModelsAsync()
        {
            return await _modelRepository.GetAllAsync();
        }

        public async Task<Model> UpdateModelAsync(Model model)
        {
            Guard.AgainstNull(model, "model");
            var result = await _modelRepository.UpdateAsync(model);
            if (result != null)
            {
                _logger.LogInformation($"Updated model, Id = {model.Id}");
            }
            else
            {
                _logger.LogWarning($"Could not update model, Id = {model.Id}");
            }
            return result;
        }
    }
}
