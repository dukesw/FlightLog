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
    public class MaintenanceLogTypeService : IMaintenanceLogTypeService
    {
        private readonly IMaintenanceLogTypeRepository _maintenanceLogTypeRepository;
        private readonly IAppLogger<MaintenanceLogTypeService> _logger;
        private readonly IMapper _mapper;

        public MaintenanceLogTypeService(IMaintenanceLogTypeRepository maintenanceLogTypeRepository, IAppLogger<MaintenanceLogTypeService> logger, IMapper mapper)
        {
            Guard.AgainstNull(maintenanceLogTypeRepository, "maintenanceLogTypeRepository");
            Guard.AgainstNull(logger, "logger");
            Guard.AgainstNull(mapper, "mapper");

            _maintenanceLogTypeRepository = maintenanceLogTypeRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<MaintenanceLogTypeDto> AddMaintenanceLogTypeAsync(MaintenanceLogTypeDto maintenanceLogType)
        {
            Guard.AgainstNull(maintenanceLogType, "maintenanceLogType");
            var maintenanceLogTypeEntity = _mapper.Map<MaintenanceLogTypeDto, MaintenanceLogType>(maintenanceLogType);

            try
            {
                await _maintenanceLogTypeRepository.AddAsync(maintenanceLogTypeEntity);
                _logger.LogInformation($"Added maintenance log type, new Id = {maintenanceLogTypeEntity.Id}");
                return await GetMaintenanceLogTypeByIdAsync(maintenanceLogTypeEntity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error adding maintenance log type: {maintenanceLogType}.");
                return null;
            }
        }

        public async Task DeleteMaintenanceLogTypeAsync(int id)
        {
            try
            {
                var maintenanceLogTypeToDelete = _maintenanceLogTypeRepository.GetById(id);
                Guard.AgainstNull(maintenanceLogTypeToDelete, "maintenanceLogTypeToDelete");
              
                await _maintenanceLogTypeRepository.DeleteAsync(maintenanceLogTypeToDelete);
                _logger.LogInformation($"Deleted maintenance log type with Id: {id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting maintenance log with Id: {id}");
                throw;
            }
        }

        public async Task<MaintenanceLogTypeDto> GetMaintenanceLogTypeByIdAsync(int id)
        {
            var result = await _maintenanceLogTypeRepository.GetByIdAsync(id);
            Guard.AgainstNull(result, "result");
            return _mapper.Map<MaintenanceLogType, MaintenanceLogTypeDto>(result);
        }

        public async Task<IList<MaintenanceLogTypeDto>> GetMaintenanceLogTypesAsync()
        {
            var result = await _maintenanceLogTypeRepository.GetAllAsync();
            return _mapper.Map<IList<MaintenanceLogType>, IList<MaintenanceLogTypeDto>>(result);
        }

        public async Task<MaintenanceLogTypeDto> UpdateMaintenanceLogTypeAsync(MaintenanceLogTypeDto maintenanceLogType)
        {
            Guard.AgainstNull(maintenanceLogType, "maintenanceLogType");
            
            var maintenanceLogTypeEntity = _mapper.Map<MaintenanceLogTypeDto, MaintenanceLogType>(maintenanceLogType);

            var result = await _maintenanceLogTypeRepository.UpdateAsync(maintenanceLogTypeEntity);
            if (result != null)
            {
                _logger.LogInformation($"Updated maintenance log type, Id = {maintenanceLogTypeEntity.Id}");
            }
            else
            {
                _logger.LogWarning($"Could not update maintenance log type, Id = {maintenanceLogTypeEntity.Id}");
            }
            return await GetMaintenanceLogTypeByIdAsync(maintenanceLogTypeEntity.Id);

        }
    }
}
