using DukeSoftware.FlightLog.Shared.Dtos;
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
        Task<IList<FlightDto>> GetRecentFlightsAsync(int accountId);
        Task<IList<FlightDto>> GetFlightsByModelAsync(int accountId, int modelId);
        Task<IList<FlightDto>> GetFlightsByDateAsync(int accountId, DateTime startDate, DateTime endDate);
        Task<IList<FlightDto>> GetFlightsByDateAndModelAsync(int accountId, DateTime startDate, DateTime endDate, int modelId);
        Task<FlightDto> GetFlightByIdAsync(int accountId, int id);
        Task<int> GetFlightCountByModelAsync(int accountId, int modelId);
        Task<FlightSummaryDto> GetFlightSummaryByModelAsync(int accountId, int modelId);
        Task<FlightSummaryDto> GetFlightSummaryByDateRange(int accountId, DateTime startDate, DateTime endDate);
        Task<IList<FlightGroupDto>> GetGroupedFlightsByMonthAndModelForDates(int accountId, DateTime startDate, DateTime endDate);
        Task<FlightSummaryDto> GetFlightSummaryByModelAndDateRange(int accountId, int modelId, DateTime startDate, DateTime endDate);
        Task<FlightDto> AddFlightAsync(int accountId, FlightDto flight);
        Task<FlightDto> UpdateFlightAsync(int accountId, FlightDto flight);
        Task DeleteFlightAsync(int accountId, int id);
    }
}
