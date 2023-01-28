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
    public class MaintenanceLogService : IMaintenanceLogService
    {
        private readonly IMaintenanceLogRepository _maintenanceLogRepository;
        private readonly IAppLogger<MaintenanceLogService> _logger;
        private readonly IMapper _mapper;

        public MaintenanceLogService(IMaintenanceLogRepository maintenanceLogRepository, IAppLogger<MaintenanceLogService> logger, IMapper mapper)
        {
            Guard.AgainstNull(maintenanceLogRepository, "maintenanceLogRepository");
            Guard.AgainstNull(logger, "logger");
            Guard.AgainstNull(mapper, "mapper");

            _maintenanceLogRepository = maintenanceLogRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<MaintenanceLogDto> AddMaintenanceLogAsync(int accountId, MaintenanceLogDto maintenanceLog)
        {
            Guard.AgainstNull(maintenanceLog, "maintenanceLog");
            Guard.AgainstAccountNumberMismatch(accountId, maintenanceLog.AccountId, "accountId", "model.AccountId");
            var maintenanceLogEntity = _mapper.Map<MaintenanceLogDto, MaintenanceLog>(maintenanceLog);

            try
            {
                await _maintenanceLogRepository.AddAsync(maintenanceLogEntity);
                _logger.LogInformation($"Added maintenance log, new Id = {maintenanceLogEntity.Id}");
                return await GetMaintenanceLogByIdAsync(accountId, maintenanceLogEntity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error adding maintenance log: {maintenanceLog}.");
                return null;
            }
        }

        public async Task DeleteMaintenanceLogAsync(int accountId, int id)
        {
            try
            {
                var maintenanceLogToDelete = _maintenanceLogRepository.GetById(id);
                Guard.AgainstNull(maintenanceLogToDelete, "maintenanceLogToDelete");
                Guard.AgainstAccountNumberMismatch(accountId, maintenanceLogToDelete.AccountId, "accountId", "maintenanceLogToDelete.AccountId");

                await _maintenanceLogRepository.DeleteAsync(maintenanceLogToDelete);
                _logger.LogInformation($"Deleted maintenance log with Id: {id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting maintenance log with Id: {id}");
                throw;
            }
        }

        public async Task<MaintenanceLogDto> GetMaintenanceLogByIdAsync(int accountId, int id)
        {
            var spec = new GetMaintenanceLogByAccountAndIdWithIncludes(accountId, id);
            var result = await _maintenanceLogRepository.GetBySpecAsync(spec);
            Guard.AgainstNull(result.FirstOrDefault(), "result");
            return _mapper.Map<MaintenanceLog, MaintenanceLogDto>(result.FirstOrDefault());
        }

        public async Task<IList<MaintenanceLogDto>> GetMaintenanceLogsByModelIdAsync(int accountId, int id)
        {
            var spec = new GetMaintenanceLogByAccountAndModel(accountId, id);
            var result = await _maintenanceLogRepository.GetBySpecAsync(spec);
            return _mapper.Map<IList<MaintenanceLog>, IList<MaintenanceLogDto>>(result.OrderBy(x => x.Date).ToList());
        }

        public async Task<IList<MaintenanceLogDto>> GetMaintenanceLogsAsync(int accountId)
        {
            // TODO - In order to get the result looking nicer add a "WithIncludes" version of the spec. 
            var spec = new GetMaintenanceLogsByAccount(accountId);
            var result = await _maintenanceLogRepository.GetBySpecAsync(spec);
            return _mapper.Map<IList<MaintenanceLog>, IList<MaintenanceLogDto>>(result);
        }

        public async Task<MaintenanceLogDto> UpdateMaintenanceLogAsync(int accountId, MaintenanceLogDto maintenanceLog)
        {
            Guard.AgainstNull(maintenanceLog, "maintenance log");
            Guard.AgainstAccountNumberMismatch(accountId, maintenanceLog.AccountId, "accountId", "maintenanceLog.AccountId");

            var maintenanceLogEntity = _mapper.Map<MaintenanceLogDto, MaintenanceLog>(maintenanceLog);

            var result = await _maintenanceLogRepository.UpdateAsync(maintenanceLogEntity);
            if (result != null)
            {
                _logger.LogInformation($"Updated maintenance log, Id = {maintenanceLogEntity.Id}");
            }
            else
            {
                _logger.LogWarning($"Could not update maintenance log, Id = {maintenanceLogEntity.Id}");
            }
            return await GetMaintenanceLogByIdAsync(accountId, maintenanceLogEntity.Id);

        }
    }
}
