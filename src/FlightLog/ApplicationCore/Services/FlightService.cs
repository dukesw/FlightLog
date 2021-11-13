using AutoMapper;
using DukeSoftware.FlightLog.Shared.Dtos;
using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using DukeSoftware.FlightLog.ApplicationCore.Specifications;
using DukeSoftware.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DukeSoftware.FlightLog.ApplicationCore.Services
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IAppLogger<FlightService> _logger;
        private readonly IMapper _mapper;
        public FlightService(IFlightRepository repository, IAppLogger<FlightService> logger, IMapper mapper)
        {
            _flightRepository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<FlightDto> AddFlightAsync(int accountId, FlightDto flight)
        {
            Guard.AgainstNull(flight, "flight");
            Guard.AgainstAccountNumberMismatch(accountId, flight.AccountId, "accountId", "flight.AccountId");
            var flightEntity = _mapper.Map<FlightDto, Flight>(flight);

            try
            {
                flightEntity = await _flightRepository.AddAsync(flightEntity);
                _logger.LogInformation($"Added flight, new Id = {flightEntity.Id}");
                return await GetFlightByIdAsync(accountId, flightEntity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error adding flight: {flight}.");
                throw; 
            }
        }

        public async Task DeleteFlightAsync(int accountId, int id)
        {
            try
            {
                var flightToDelete = _flightRepository.GetById(id);
                Guard.AgainstNull(flightToDelete, "flightToDelete");
                Guard.AgainstAccountNumberMismatch(accountId, flightToDelete.AccountId, "accountId", "flightToDelete.AccountId");

                await _flightRepository.DeleteAsync(flightToDelete);
                _logger.LogInformation($"Deleted flight with Id: {id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting flight with Id: {id}");
                throw;
            }
        }

        public async Task<FlightDto> GetFlightByIdAsync(int accountId, int id)
        {
            // todo include a SpecificationBase class then create an instance from there
            var spec = new GetFlightByIdWithIncludes(id);
            var result = await _flightRepository.GetBySpecAsync(spec);
            Guard.AgainstNull(result.FirstOrDefault(), "result");
            return _mapper.Map<Flight, FlightDto>(result.FirstOrDefault());
        }

        public async Task<IList<FlightDto>> GetFlightsAsync(int accountId)
        {
            var spec = new GetFlightsByAccount(accountId);
            var result = await _flightRepository.GetBySpecAsync(spec);
            return _mapper.Map<IList<Flight>, IList<FlightDto>>(result);
        }

        public async Task<IList<FlightDto>> GetRecentFlightsAsync(int accountId)
        {
            // Defining recent flights as all of those within the last month, based on the date of the request
            var dateFrom = DateTime.Now.AddMonths(-1);
            var spec = new GetFlightsByAccountAndDateRange(accountId, dateFrom, DateTime.Now);
            var result = await _flightRepository.GetBySpecAsync(spec);
            return _mapper.Map<IList<Flight>, IList<FlightDto>>(result);
        }

        public async Task<IList<FlightDto>> GetFlightsByModelAsync(int accountId, int modelId)
        {
            var spec = new GetFlightsByAccountAndModel(accountId, modelId);
            var result = await _flightRepository.GetBySpecAsync(spec);
            return _mapper.Map<IList<Flight>, IList<FlightDto>>(result);
        }

        public async Task<FlightSummaryDto> GetFlightSummaryByModelAsync(int accountId, int modelId)
        {
            var allFlights = await GetFlightsByModelAsync(accountId, modelId);
            var result = CreateFlightSummary(allFlights, accountId);
            return result;
        }

        public async Task<FlightSummaryDto> GetFlightSummaryByModelAndDateRange(int accountId, int modelId, DateTime startDate, DateTime endDate)
        {
            var allFlights = await GetFlightsByDateAndModelAsync(accountId, startDate, endDate, modelId);
            var result = CreateFlightSummary(allFlights, accountId);
            return result;
        }

        public async Task<IList<FlightDto>> GetFlightsByDateAsync(int accountId, DateTime startDate, DateTime endDate)
        {
            var spec = new GetFlightsByAccountAndDateRange(accountId, startDate, endDate);
            var result = await _flightRepository.GetBySpecAsync(spec);
            return _mapper.Map<IList<Flight>, IList<FlightDto>>(result);
        }

        public async Task<IList<FlightDto>> GetFlightsByDateAndModelAsync(int accountId, DateTime startDate, DateTime endDate, int modelId)
        {
            var spec = new GetFlightsByAccountAndDateRangeAndModel(accountId, startDate, endDate, modelId);
            var result = await _flightRepository.GetBySpecAsync(spec);
            return _mapper.Map<IList<Flight>, IList<FlightDto>>(result);
        }

        public async Task<FlightDto> UpdateFlightAsync(int accountId, FlightDto flight)
        {
            Guard.AgainstNull(flight, "flight");
            Guard.AgainstAccountNumberMismatch(accountId, flight.AccountId, "accountId", "flight.AccountId");

            var flightEntity = _mapper.Map<FlightDto, Flight>(flight);

            var result = await _flightRepository.UpdateAsync(flightEntity);
            if (result != null)
            {
                _logger.LogInformation($"Updated model, Id = {flightEntity.Id}");
            }
            else
            {
                _logger.LogWarning($"Could not update model, Id = {flightEntity.Id}");
            }
            return await GetFlightByIdAsync(accountId, result.Id);
        }

        private FlightSummaryDto CreateFlightSummary(IList<FlightDto> flights, int accountId)
        {
            var result = new FlightSummaryDto();
            result.AccountId = accountId;
            if (flights.Count > 0)
            {
                result.TotalFlightTimeMinutes = flights.Sum(x => x.FlightMinutes);
                result.TotalNumberOfFlights = flights.Count;
                result.AverageFlightTimeMinutes = flights.Average(x => x.FlightMinutes);
                result.FirstFlight = flights.Min(x => x.Date);
                result.LastFlight = flights.Max(x => x.Date);
            };

            return result;
        }

    }
}
