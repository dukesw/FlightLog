// Copyright DukeSoftware 2018 $(itemName)
using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DukeSoftware.FlightLog.ApplicationCore.Interfaces
{
    public interface IFlightRepository : IRepository<Flight>, IAsyncRepository<Flight>
    {
        Task<IList<FlightGroupDto>> GetGroupedFlightsByMonthAndModelForDates(int accountId, DateTime startDate, DateTime endDate);
    }
}