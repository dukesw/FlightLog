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
            }
        }

        public async Task<Flight> GetFlightByIdAsync(long id)
        {
            // todo include a SpecificationBase class then create an instance from there
            var spec = new GetFlightByIdWithModel(id);
            var result = await _flightRepository.ListAsync(spec);
            return result.FirstOrDefault();
        }

        public async Task<List<Flight>> GetFlightsAsync()
        {
            // Could also create a specification... 
            var includes = new List<Expression<Func<Flight, object>>>();
            includes.Add(f => f.Model);
            return await _flightRepository.ListAllAsync(includes);
        }

        public async Task<List<Flight>> GetFlightsAsync(Model model)
        {
            throw new NotImplementedException();
        }

        public async Task<Model> UpdateFlightAsync(Flight flight)
        {
            throw new NotImplementedException();
        }
    }
}
