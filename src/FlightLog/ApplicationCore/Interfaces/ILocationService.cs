using DukeSoftware.FlightLog.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DukeSoftware.FlightLog.ApplicationCore.Interfaces
{
    public interface ILocationService
    {
        Task<List<Location>> GetLocationsAsync(int accountId);
        Task<Location> GetLocationByIdAsync(int accountId, int id);
        Task<Location> AddLocationAsync(int accountId, Location location);
        Task<Location> UpdateLocationAsync(int accountId, Location location);
        Task DeleteLocationAsync(int accountId, int id);
    }
}
