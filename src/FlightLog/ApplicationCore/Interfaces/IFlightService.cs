using DukeSoftware.FlightLog.ApplicationCore.Dtos;
using DukeSoftware.FlightLog.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DukeSoftware.FlightLog.ApplicationCore.Interfaces
{
    public interface IFlightService
    {

        Task<List<Flight>> GetFlightsAsync(int accountId);
        Task<IList<FlightDto>> GetFlightsByModelAsync(int accountId, int modelId);
        Task<List<Flight>> GetFlightsByDateAsync(int accountId, DateTime startDate, DateTime endDate);
        Task<List<Flight>> GetFlightsByDateAndModelAsync(int accountId, DateTime startDate, DateTime endDate, int modelId);
        Task<Flight> GetFlightByIdAsync(int accountId, int id);
        Task<FlightSummaryDto> GetFlightSummaryByModelAsync(int accountId, int modelId); 
        Task<Flight> AddFlightAsync(int accountId, Flight flight);
        Task<Flight> UpdateFlightAsync(int accountId, Flight flight);
        Task DeleteFlightAsync(int accountId, int id);
    }
}
