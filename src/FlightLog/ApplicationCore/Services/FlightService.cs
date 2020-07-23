﻿using AutoMapper;
using DukeSoftware.FlightLog.ApplicationCore.Dtos;
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

        public async Task<Flight> AddFlightAsync(Flight flight)
        {
            Guard.AgainstNull(flight, "flight");
            try
            {
                flight = await _flightRepository.AddAsync(flight);
                _logger.LogInformation($"Added flight, new Id = {flight.Id}");
                return flight;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error adding flight: {flight}.");
                throw; 
            }
        }

        public async Task DeleteFlightAsync(int id)
        {
            try
            {
                var flightToDelete = _flightRepository.GetById(id);
                Guard.AgainstNull(flightToDelete, "flightToDelete");
                await _flightRepository.DeleteAsync(flightToDelete);
                _logger.LogInformation($"Deleted flight with Id: {id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting flight with Id: {id}");
                throw;
            }
        }

        public async Task<Flight> GetFlightByIdAsync(int id)
        {
            // todo include a SpecificationBase class then create an instance from there
            var spec = new GetFlightByIdWithIncludes(id);
            var result = await _flightRepository.GetBySpecAsync(spec);
            Guard.AgainstNull(result.FirstOrDefault(), "result");
            return result.FirstOrDefault();
        }

        public async Task<List<Flight>> GetFlightsAsync()
        {
            // FIXME next sort this out with a spec. Or have a default one as we are getting to have a lot of specs
            // Could also create a specification... 
            //var spec = new GetAllFlightsWithAllProperties();
            return  await _flightRepository.GetAllAsync();
        }

        public async Task<IList<FlightDto>> GetFlightsByModelAsync(int modelId)
        {
            var spec = new GetFlightsByModel(modelId);
            var result = await _flightRepository.GetBySpecAsync(spec);
            return _mapper.Map<IList<Flight>, IList<FlightDto>>(result);
        }

        public async Task<FlightSummaryDto> GetFlightSummaryByModelAsync(int modelId)
        {
            var allFlights = await GetFlightsByModelAsync(modelId);
            var result = CreateFlightSummary(allFlights);
            return result;
        }

        private FlightSummaryDto CreateFlightSummary(IList<FlightDto> flights)
        {
            var result = new FlightSummaryDto
            {
                TotalFlightTimeMinutes = flights.Sum(x => x.FlightMinutes),
                TotalNumberOfFlights = flights.Count,
                AverageFlightTimeMinutes = flights.Average(x => x.FlightMinutes),
                FirstFlight = flights.Min(x => x.Date),
                LastFlight = flights.Max(x => x.Date)
            };

            return result;
        }

        public async Task<List<Flight>> GetFlightsByDateAsync(DateTime startDate, DateTime endDate)
        {
            var spec = new GetFlightsByDateRange(startDate, endDate);
            return await _flightRepository.GetBySpecAsync(spec);
        }

        public async Task<Flight> UpdateFlightAsync(Flight flight)
        {
            Guard.AgainstNull(flight, "flight");
            var result = await _flightRepository.UpdateAsync(flight);
            if (result != null)
            {
                _logger.LogInformation($"Updated model, Id = {flight.Id}");
            }
            else
            {
                _logger.LogWarning($"Could not update model, Id = {flight.Id}");
            }
            return result;
        }
    }
}
