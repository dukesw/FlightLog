using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using DukeSoftware.FlightLog.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.Infrastructure.Data
{
    public class FlightRepository : EfRepository<Flight>, IFlightRepository
    {
        public FlightRepository(FlightLogContext context) : base(context)
        {
        }

        public async Task<IList<FlightGroupDto>> GetGroupedFlightsByMonthForDates(int accountId, DateTime startDate, DateTime endDate)
        {
            var query = from f in _dbContext.Set<Flight>()
                        where f.Date >= startDate
                        where f.Date <= endDate
                        group f by new { f.Date.Year, f.Date.Month, f.ModelId, f.Model.Name }
                        into fg
                        orderby fg.Key.Year, fg.Key.Month, fg.Key.ModelId
                        select new FlightGroupDto
                        {
                            PeriodName = $"{new DateTime(fg.Key.Year, fg.Key.Month, 1).ToString("MMM")} {fg.Key.Year}",
                            Model = new FlightModelDto { Id = fg.Key.ModelId, Name = fg.Key.Name },
                            FlightCount = fg.Count(),
                            FightMinutesSum = fg.Sum(x => x.FlightMinutes),
                            StartDate = new DateTime(fg.Key.Year, fg.Key.Month, 1),
                            EndDate = new DateTime(fg.Key.Year, fg.Key.Month, 1).AddMonths(1).AddSeconds(-1),
                        };

            return await query.ToListAsync();

        }
    }
}

