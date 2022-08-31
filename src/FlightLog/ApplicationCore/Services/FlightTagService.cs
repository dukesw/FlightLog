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
    public class FlightTagService : IFlightTagService
    {
        private readonly IFlightTagRepository _flightTagRepository;
        private readonly IAppLogger<FlightTagService> _logger;
        private readonly IMapper _mapper;

        public FlightTagService(IFlightTagRepository flightTagRepository, IAppLogger<FlightTagService> logger, IMapper mapper)
        {
            Guard.AgainstNull(flightTagRepository, "flightTagRepository");
            Guard.AgainstNull(logger, "logger");
            Guard.AgainstNull(mapper, "mapper");

            _flightTagRepository = flightTagRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<FlightTagDto> AddFlightTagAsync(FlightTagDto flightTag)
        {
            Guard.AgainstNull(flightTag, "flightTag");
            var flightTagEntity = _mapper.Map<FlightTagDto, FlightTag>(flightTag);

            try
            {
                await _flightTagRepository.AddAsync(flightTagEntity);
                _logger.LogInformation($"Added flight tag, new Id = {flightTagEntity.Id}");
                return await GetFlightTagByIdAsync(flightTagEntity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error adding flight tag: {flightTag}.");
                return null;
            }
        }

        public async Task DeleteFlightTagAsync(int id)
        {
            try
            {
                var flightTagToDelete = _flightTagRepository.GetById(id);
                Guard.AgainstNull(flightTagToDelete, "flightTagToDelete");
              
                await _flightTagRepository.DeleteAsync(flightTagToDelete);
                _logger.LogInformation($"Deleted flight tag with Id: {id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting flight tag with Id: {id}");
                throw;
            }
        }

        public async Task<FlightTagDto> GetFlightTagByIdAsync(int id)
        {
            var result = await _flightTagRepository.GetByIdAsync(id);
            Guard.AgainstNull(result, "result");
            return _mapper.Map<FlightTag, FlightTagDto>(result);
        }

        public async Task<IList<FlightTagDto>> GetFlightTagsAsync()
        {
            var result = await _flightTagRepository.GetAllAsync();
            return _mapper.Map<IList<FlightTag>, IList<FlightTagDto>>(result);
        }

        public async Task<FlightTagDto> UpdateFlightTagAsync(FlightTagDto flightTag)
        {
            Guard.AgainstNull(flightTag, "flightTag");
            
            var flightTagEntity = _mapper.Map<FlightTagDto, FlightTag>(flightTag);

            var result = await _flightTagRepository.UpdateAsync(flightTagEntity);
            if (result != null)
            {
                _logger.LogInformation($"Updated flight tag, Id = {flightTagEntity.Id}");
            }
            else
            {
                _logger.LogWarning($"Could not update flight tag, Id = {flightTagEntity.Id}");
            }
            return await GetFlightTagByIdAsync(flightTagEntity.Id);

        }
    }
}
