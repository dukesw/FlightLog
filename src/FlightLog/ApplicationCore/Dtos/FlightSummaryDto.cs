using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Dtos
{
    public class FlightSummaryDto
    {
        public float TotalFlightTimeMinutes { get; set; }
        public int TotalNumberOfFlights { get; set; }
        public float AverageFlightTimeMinutes { get; set; }
        public DateTime? FirstFlight { get; set; }
        public DateTime? LastFlight { get; set; }
        // Are flights needed???  
        public int AccountId { get; set; }
    }
}
