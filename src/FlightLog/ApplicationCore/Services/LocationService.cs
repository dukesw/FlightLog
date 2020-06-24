using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using DukeSoftware.GuardClauses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DukeSoftware.FlightLog.ApplicationCore.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IAppLogger<LocationService> _logger;

        public LocationService(ILocationRepository locationRepository, IAppLogger<LocationService> logger)
        {
            Guard.AgainstNull(locationRepository, "locationRepository");
            Guard.AgainstNull(logger, "logger");

            this._locationRepository = locationRepository;
            this._logger = logger;
        }
        public async Task<Location> AddLocationAsync(Location location)
        {
            Guard.AgainstNull(location, "location");
            try
            {
                await _locationRepository.AddAsync(location);
                _logger.LogInformation($"Added location, new Id = {location.Id}");
                return location;
            } 
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error adding location: {location}.");
                return null;
            }
        }

        public Task DeleteLocationAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Location> GetLocationByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Location>> GetLocationsAsync()
        {
            return await _locationRepository.GetAllAsync();
        }

        public Task<Location> UpdateLocationAsync(Location location)
        {
            throw new NotImplementedException();
        }
    }
}
