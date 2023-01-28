using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using DukeSoftware.FlightLog.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DukeSoftware.FlightLog.Infrastructure.Data
{
    public class FlightRepository : EfRepository<Flight>, IFlightRepository
    {
        public FlightRepository(FlightLogContext context) : base(context)
        {
        }

        public async Task<IList<FlightsGroupedByModelAndTimeDto>> GetGroupedFlightsByMonthAndModelForDates(int accountId, DateTime startDate, DateTime endDate)
        {
            var query = from f in _dbContext.Set<Flight>()
                        where f.Date >= startDate
                        where f.Date <= endDate
                        group f by new { f.Date.Year, f.Date.Month, f.ModelId, f.Model.Name }
                        into fg
                        orderby fg.Key.Year, fg.Key.Month, fg.Key.ModelId
                        select new FlightsGroupedByModelAndTimeDto
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

        public async Task<IList<FlightsGroupedByTimeDto>> GetGroupedFlightsByWeekForDates(int accountId, DateTime startDate, DateTime endDate)
        {
            // Align the start date to weeks... 
            var weekStartDate = GetStartOfWeekDate(startDate);
            var weekEndDate = GetEndOfWeekDate(endDate);

            var query = from f in _dbContext.Set<Flight>()
                        where f.Date >= weekStartDate
                        where f.Date <= weekEndDate
                        select f;
            var flights = await query.ToListAsync();

            var groupQuery = from f in flights
                             group f by new { Year = ISOWeek.GetYear(f.Date), Week = ISOWeek.GetWeekOfYear(f.Date) }
                        into fg
                        orderby fg.Key.Year, fg.Key.Week
                        select new FlightsGroupedByTimeDto
                        {
                            //PeriodName = $"Week {fg.Key.Week} {fg.Key.Year}",

                            PeriodName = $"{ISOWeek.ToDateTime(fg.Key.Year, fg.Key.Week, DayOfWeek.Monday).ToString("d-MMM")}",
                            FlightCount = fg.Count(),
                            FightMinutesSum = fg.Sum(x => x.FlightMinutes),
                            StartDate = ISOWeek.ToDateTime(fg.Key.Year, fg.Key.Week, DayOfWeek.Monday),
                            EndDate = ISOWeek.ToDateTime(fg.Key.Year, fg.Key.Week, DayOfWeek.Sunday).AddDays(1).AddSeconds(-1),
                        };

            // Add in missing weeks where there were no flights
            var result = AddEmptyWeeksToGroupedFlights(weekStartDate, weekEndDate, groupQuery.ToList());
            return result;
        }

        public async Task<IList<FlightsGroupedByTimeDto>> GetGroupedFlightsByMonthForDates(int accountId, DateTime startDate, DateTime endDate)
        {
            var query = from f in _dbContext.Set<Flight>()
                        where f.Date >= startDate
                        where f.Date <= endDate
                        group f by new { f.Date.Year, f.Date.Month }
                        into fg
                        orderby fg.Key.Year, fg.Key.Month
                        select new FlightsGroupedByTimeDto
                        {
                            PeriodName = $"{new DateTime(fg.Key.Year, fg.Key.Month, 1).ToString("MMM")}",
                            FlightCount = fg.Count(),
                            FightMinutesSum = fg.Sum(x => x.FlightMinutes),
                            StartDate = new DateTime(fg.Key.Year, fg.Key.Month, 1),
                            EndDate = new DateTime(fg.Key.Year, fg.Key.Month, 1).AddMonths(1).AddSeconds(-1),
                        };

            var result = await query.ToListAsync();
            return AddEmptyMonthsToGroupedFlights(startDate, endDate, result);
        }

        private static IList<FlightsGroupedByTimeDto> AddEmptyWeeksToGroupedFlights(DateTime startDate, DateTime endDate, IList<FlightsGroupedByTimeDto> result)
        {
            var firstWeekStartDate = ISOWeek.ToDateTime(startDate.Year, ISOWeek.GetWeekOfYear(startDate), DayOfWeek.Monday);
            var endWeekStartDate = ISOWeek.ToDateTime(endDate.Year, ISOWeek.GetWeekOfYear(endDate), DayOfWeek.Monday);

            for (var indexDate = firstWeekStartDate; indexDate < endWeekStartDate; indexDate = indexDate.AddDays(7))
            {
                if (!result.Any(x => x.StartDate == indexDate))
                {
                    result.Add(new FlightsGroupedByTimeDto
                    {
                        StartDate = indexDate,
                        EndDate = indexDate.AddDays(7).AddSeconds(-1),
                        PeriodName = indexDate.ToString("d-MMM"),
                        FlightCount = 0,
                        FightMinutesSum = 0
                    });
                }
            }

            return result.OrderBy(x => x.StartDate).ToList();
        }

        private static IList<FlightsGroupedByTimeDto> AddEmptyMonthsToGroupedFlights(DateTime startDate, DateTime endDate, IList<FlightsGroupedByTimeDto> result)
        {
            var firstMonthStartDate = new DateTime(startDate.Year, startDate.Month, 1);
            var lastMonthStartDate = new DateTime(endDate.Year, endDate.Month, 1);

            for (var indexDate = firstMonthStartDate; indexDate <= lastMonthStartDate; indexDate = indexDate.AddMonths(1))
            {
                if (!result.Any(x => x.StartDate == indexDate))
                {
                    result.Add(new FlightsGroupedByTimeDto
                    {
                        StartDate = indexDate,
                        EndDate = indexDate.AddMonths(1).AddDays(-1),
                        PeriodName = indexDate.ToString("MMM"),
                        FlightCount = 0,
                        FightMinutesSum = 0
                    });
                }
            }

            return result.OrderBy(x => x.StartDate).ToList();
        }

        private DateTime GetStartOfWeekDate(DateTime date)
        {
            return ISOWeek.ToDateTime(date.Year, ISOWeek.GetWeekOfYear(date), DayOfWeek.Sunday);
        }

        private DateTime GetEndOfWeekDate(DateTime date)
        {
            return ISOWeek.ToDateTime(date.Year, ISOWeek.GetWeekOfYear(date), DayOfWeek.Sunday);
        }
    }
}

