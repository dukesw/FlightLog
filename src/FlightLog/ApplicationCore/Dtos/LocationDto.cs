using System.Collections.Generic;

namespace DukeSoftware.FlightLog.ApplicationCore.Dtos
{
    public class LocationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string WeatherStationLink { get; set; }
        public int AccountId { get; set; }
        public IList<FlightDto> Flights { get; set; }
    }
}