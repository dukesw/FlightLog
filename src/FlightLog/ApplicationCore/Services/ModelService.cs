using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using DukeSoftware.FlightLog.ApplicationCore.Specifications;
using DukeSoftware.FlightLog.Shared.Dtos;
using DukeSoftware.GuardClauses;

namespace DukeSoftware.FlightLog.ApplicationCore.Services
{
    public class ModelService : IModelService
    {
        private readonly IModelRepository _modelRepository;
        private readonly IAppLogger<ModelService> _logger;
        private readonly IMapper _mapper;
        public ModelService(IModelRepository modelRepository, IAppLogger<ModelService> logger, IMapper mapper)
        {
            Guard.AgainstNull(modelRepository, "modelRepository");
            Guard.AgainstNull(logger, "logger");

            _modelRepository = modelRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ModelDto> AddModelAsync(int accountId, ModelDto model)
        {
            Guard.AgainstNull(model, "model");
            Guard.AgainstAccountNumberMismatch(accountId, model.AccountId, "accountId", "model.AccountId");
            var modelEntity = _mapper.Map<ModelDto, Model>(model);
            modelEntity.TotalFlights = modelEntity.LoggedFlights + modelEntity.UnloggedFlights;

            try
            {
                await _modelRepository.AddAsync(modelEntity);
                _logger.LogInformation($"Added model, new Id = {modelEntity.Id}");
                return await GetModelByIdAsync(accountId, modelEntity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error adding model: {model}.");
                return null;
            }
        }

        public async Task DeleteModelAsync(int accountId, int id)
        {
            try
            {
                var modelToDelete = _modelRepository.GetById(id);
                Guard.AgainstNull(modelToDelete, "modelToDelete");
                Guard.AgainstAccountNumberMismatch(accountId, modelToDelete.AccountId, "accountId", "modelToDelete.AccountId");

                await _modelRepository.DeleteAsync(modelToDelete);
                _logger.LogInformation($"Deleted model with Id: {id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting model with Id: {id}");
                throw;
            }
        }

        public async Task<ModelDto> GetModelByIdAsync(int accountId, int id)
        {
            var spec = new GetModelByAccountAndIdWithIncludes(accountId, id);
            var result = await _modelRepository.GetBySpecAsync(spec);
            Guard.AgainstNull(result.FirstOrDefault(), "result");
            return _mapper.Map<Model, ModelDto>(result.FirstOrDefault());
        }

        public async Task<IList<ModelDto>> GetModelsAsync(int accountId)
        {
            var spec = new GetModelsByAccountId(accountId);
            var result = await _modelRepository.GetBySpecAsync(spec);
            return _mapper.Map<IList<Model>, IList<ModelDto>>(result);
        }

        public async Task<IList<ModelDto>> GetModelsSortedBySortOrderAsync(int accountId)
        {
            var spec = new GetModelsByAccountIdSortedBySortOrder(accountId);
            var result = await _modelRepository.GetBySpecAsync(spec);
            return _mapper.Map<IList<Model>, IList<ModelDto>>(result);
        }

        public async Task<int> GetModelsCountsAsync(int accountId)
        {
            var spec = new GetModelsByAccountId(accountId);
            var result = await _modelRepository.GetCountBySpecAsync(spec);
            return result;
        }

        public async Task<IList<ModelDto>> GetModelsByPageAsync(int accountId, int skip, int take)
        {
            var spec = new GetModelsByAccountIdByPage(accountId, skip, take);
            var result = await _modelRepository.GetBySpecAsync(spec);
            return _mapper.Map<IList<Model>, IList<ModelDto>>(result);
        }
        public async Task<IList<ModelDto>> GetModelsByPageSortedAsync(int accountId, string sortBy, bool isDescending, int skip, int take)
        {
            var spec = new GetModelsByAccountIdByPage(accountId, skip, take, sortBy, isDescending);
            var result = await _modelRepository.GetBySpecAsync(spec);
            return _mapper.Map<IList<Model>, IList<ModelDto>>(result);
        }
        

        public async Task<IList<ModelDto>> GetModelsByIsActiveAsync(int accountId, bool isActive)
        {
            var spec = new GetModelsByAccountIdAndIsActive(accountId, isActive);
            var result = await _modelRepository.GetBySpecAsync(spec);
            return _mapper.Map<IList<Model>, IList<ModelDto>>(result);
        }

        public async Task<ModelDto> UpdateModelAsync(int accountId, ModelDto model)
        {
            Guard.AgainstNull(model, "model");
            Guard.AgainstAccountNumberMismatch(accountId, model.AccountId, "accountId", "model.AccountId");

            var modelEntity = _mapper.Map<ModelDto, Model>(model);
            modelEntity.TotalFlights = modelEntity.LoggedFlights + modelEntity.UnloggedFlights;

            var result = await _modelRepository.UpdateAsync(modelEntity);
            if (result != null)
            {
                _logger.LogInformation($"Updated model, Id = {modelEntity.Id}");
            }
            else
            {
                _logger.LogWarning($"Could not update model, Id = {modelEntity.Id}");
            }
            return await GetModelByIdAsync(accountId, modelEntity.Id);
        }
    }
}
