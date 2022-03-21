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
            //var query = from f in _dbContext.Set<Flight>()
            //            where f.Date >= startDate
            //            where f.Date <= endDate
            //            let week = GetWeekNumber(f.Date)
            //            let year = f.Date.Year
            //            group new { f.Date.Year } by year and by week
            //            into fg
            //            //orderby fg.Year //, //Year, fg.Key.week
            //            select new FlightsGroupedByTimeDto
            //            {
            //                PeriodName = $"Week {fg.Key.week} {fg.Key.Year}",
            //                FlightCount = fg.Count(),
            //                FightMinutesSum = fg.Sum(x => x.FlightMinutes),
            //                StartDate = ISOWeek.ToDateTime(fg.Key.Year, fg.Key.week, DayOfWeek.Monday),
            //                EndDate = ISOWeek.ToDateTime(fg.Key.Year, fg.Key.week, DayOfWeek.Sunday),
            //            };

            // Align the start date to weeks... 
            var weekStartDate = GetStartOfWeekDate(startDate);
            var weekEndDate = GetEndOfWeekDate(endDate);

            var query = from f in _dbContext.Set<Flight>()
                        where f.Date >= weekStartDate
                        where f.Date <= weekEndDate
                        select f;
            var flights = await query.ToListAsync();

            var groupQuery = from f in flights
                             group f by new { f.Date.Year, Week = ISOWeek.GetWeekOfYear(f.Date) }
                        into fg
                        orderby fg.Key.Year, fg.Key.Week
                        select new FlightsGroupedByTimeDto
                        {
                            //PeriodName = $"Week {fg.Key.Week} {fg.Key.Year}",

                            PeriodName = $"{ISOWeek.ToDateTime(fg.Key.Year, fg.Key.Week, DayOfWeek.Monday).ToString("d-MMM")}",
                            FlightCount = fg.Count(),
                            FightMinutesSum = fg.Sum(x => x.FlightMinutes),
                            StartDate = ISOWeek.ToDateTime(fg.Key.Year, fg.Key.Week, DayOfWeek.Monday),
                            EndDate = ISOWeek.ToDateTime(fg.Key.Year, fg.Key.Week, DayOfWeek.Sunday),
                        };

            // Add in missing weeks where there were no flights
            var result = AddEmptyWeeksToGroupedFlights(weekStartDate, weekEndDate, groupQuery.ToList());
            return result;
        }

        private static IList<FlightsGroupedByTimeDto> AddEmptyWeeksToGroupedFlights(DateTime startDate, DateTime endDate, IList<FlightsGroupedByTimeDto> result)
        {
            var firstWeekStartDate = ISOWeek.ToDateTime(startDate.Year, ISOWeek.GetWeekOfYear(startDate), DayOfWeek.Monday);
            var endWeekStartDate = ISOWeek.ToDateTime(endDate.Year, ISOWeek.GetWeekOfYear(endDate), DayOfWeek.Monday);

            for (var indexDate = firstWeekStartDate; indexDate <= endWeekStartDate; indexDate = indexDate.AddDays(7))
            {
                if (!result.Any(x => x.StartDate == indexDate))
                {
                    result.Add(new FlightsGroupedByTimeDto
                    {
                        StartDate = indexDate,
                        EndDate = indexDate.AddDays(6),
                        PeriodName = indexDate.ToString("d-MMM"),
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

