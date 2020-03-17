using DukeSoftware.FlightLog.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DukeSoftware.FlightLog.ApplicationCore.Interfaces
{
    public interface IFlightService
    {

        Task<List<Flight>> ListFlightsAsync();
        Task<List<Flight>> ListFlightsAsync(Model model);
        Task<Flight> GetFlightByIdAsync(long id);
        Task<Flight> AddFlightAsync(Flight flight);
        Task<Model> UpdateFlightAsync(Flight flight);
        Task DeleteFlightAsync(long id);
    }
}
