using DukeSoftware.FlightLog.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DukeSoftware.FlightLog.ApplicationCore.Interfaces
{
    public interface IFlightService
    {

        Task<List<Flight>> GetFlightsAsync();
        Task<List<Flight>> GetFlightsAsync(int modelId);
        Task<List<Flight>> GetFlightsAsync(DateTime startDate, DateTime endDate);
        Task<Flight> GetFlightByIdAsync(int id);
        Task<Flight> AddFlightAsync(Flight flight);
        Task<Flight> UpdateFlightAsync(Flight flight);
        Task DeleteFlightAsync(int id);
    }
}
