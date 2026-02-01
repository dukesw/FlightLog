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
        Task<IList<FlightDto>> GetFlightsPagedAsync(int accountId, int skip, int take);
        Task<int> GetFlightCountAsync(int accountId);
        Task<IList<FlightDto>> GetRecentFlightsAsync(int accountId);
        Task<IList<FlightDto>> GetRecentFlightsPagedAsync(int accountId, int skip, int take);
        Task<int> GetRecentFlightCountAsync(int accountId);
        Task<IList<FlightDto>> GetFlightsByModelAsync(int accountId, int modelId);
        Task<IList<FlightDto>> GetFlightsByModelPagedAsync(int accountId, int modelId, int skip, int take);
        Task<int> GetFlightCountByModelAsync(int accountId, int modelId);
        Task<IList<FlightDto>> GetFlightsByDateRangeAsync(int accountId, DateTime fromDate, DateTime toDate);
        Task<IList<FlightDto>> GetFlightsByDateRangePagedAsync(int accountId, DateTime fromDate, DateTime toDate, int skip, int take);
        Task<int> GetFlightCountByDateRangeAsync(int accountId, DateTime fromDate, DateTime toDate);
        Task<IList<FlightDto>> GetFlightsByDateRangeAndModelAsync(int accountId, DateTime fromDate, DateTime toDate, int modelId);
        Task<IList<FlightDto>> GetFlightsByDateRangeAndModelPagedAsync(int accountId, DateTime fromDate, DateTime toDate, int modelId, int skip, int take);
        Task<int> GetFlightCountByDateRangeAndModelAsync(int accountId, DateTime fromDate, DateTime toDate, int modelId);
        Task<FlightDto> GetFlightByIdAsync(int accountId, int id);
        Task<FlightSummaryDto> GetFlightSummaryByModelAsync(int accountId, int modelId);
        Task<FlightSummaryDto> GetFlightSummaryByDateRange(int accountId, DateTime fromDate, DateTime toDate);
        Task<IList<FlightsGroupedByTimeDto>> GetGroupedFlightsByWeekForDateRange(int accountId, DateTime fromDate, DateTime toDate);
        Task<IList<FlightsGroupedByTimeDto>> GetGroupedFlightsByMonthForDateRange(int accountId, DateTime fromDate, DateTime toDate);
        Task<IList<FlightsGroupedByModelAndTimeDto>> GetGroupedFlightsByMonthAndModelForDateRange(int accountId, DateTime fromDate, DateTime toDate);
        Task<FlightSummaryDto> GetFlightSummaryByModelAndDateRange(int accountId, int modelId, DateTime fromDate, DateTime toDate);
        Task<FlightDto> AddFlightAsync(int accountId, FlightDto flight);
        Task<FlightDto> UpdateFlightAsync(int accountId, FlightDto flight);
        Task DeleteFlightAsync(int accountId, int id);
    }
}
