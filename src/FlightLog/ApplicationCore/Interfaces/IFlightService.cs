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

        Task<IList<FlightDto>> GetFlightsAsync(int accountId);
        Task<IList<FlightDto>> GetFlightsByModelAsync(int accountId, int modelId);
        Task<IList<FlightDto>> GetFlightsByDateAsync(int accountId, DateTime startDate, DateTime endDate);
        Task<IList<FlightDto>> GetFlightsByDateAndModelAsync(int accountId, DateTime startDate, DateTime endDate, int modelId);
        Task<Flight> GetFlightByIdAsync(int accountId, int id);
        Task<FlightSummaryDto> GetFlightSummaryByModelAsync(int accountId, int modelId);
        Task<FlightSummaryDto> GetFlightSummaryByModelAndDateRange(int accountId, int modelId, DateTime startDate, DateTime endDate);
        Task<Flight> AddFlightAsync(int accountId, Flight flight);
        Task<Flight> UpdateFlightAsync(int accountId, Flight flight);
        Task DeleteFlightAsync(int accountId, int id);
    }
}
