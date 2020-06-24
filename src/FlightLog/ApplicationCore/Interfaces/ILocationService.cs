using DukeSoftware.FlightLog.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DukeSoftware.FlightLog.ApplicationCore.Interfaces
{
    public interface ILocationService
    {
        Task<List<Location>> GetLocationsAsync();
        Task<Location> GetLocationByIdAsync(int id);
        Task<Location> AddLocationAsync(Location location);
        Task<Location> UpdateLocationAsync(Location location);
        Task DeleteLocationAsync(int id);
    }
}
