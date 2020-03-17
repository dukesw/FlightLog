using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using DukeSoftware.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DukeSoftware.FlightLog.ApplicationCore.Services
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IAppLogger<FlightService> _logger;
        public FlightService(IFlightRepository repository, IAppLogger<FlightService> logger)
        {
            _flightRepository = repository;
            _logger = logger;
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
                return null;
            }
        }

        public async Task DeleteFlightAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<Flight> GetFlightByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Flight>> ListFlightsAsync()
        {
            // Could also create a specification... 
            var includes = new List<Expression<Func<Flight, object>>>();
            includes.Add(f => f.Model);
            return await _flightRepository.ListAllAsync(includes);
        }

        public async Task<List<Flight>> ListFlightsAsync(Model model)
        {
            throw new NotImplementedException();
        }

        public async Task<Model> UpdateFlightAsync(Flight flight)
        {
            throw new NotImplementedException();
        }
    }
}
