using System;

namespace DukeSoftware.FlightLog.Shared.Dtos
{
    public class FlightGroupDto
    {
        public string PeriodName { get; set; }
        public FlightModelDto Model { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int FlightCount { get; set; }
        public float FightMinutesSum { get; set; }
    }
}