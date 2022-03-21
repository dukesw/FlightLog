using System;

namespace DukeSoftware.FlightLog.Shared.Dtos
{
    public class FlightsGroupedByTimeDto
    {
        public string PeriodName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int FlightCount { get; set; }
        public float FightMinutesSum { get; set; }
    }
}
