using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Entities
{
    public class Location : EntityBase
    {
        public string Name { get; set; }
        public float? Lattitude { get; set; }    // TODO - create a geo class, or reuse one
        public float? Longitude { get; set; }
        public string Notes { get; set; }
        public string WeatherStationLink { get; set; }
        public virtual IList<Flight> Flights { get; set; }
    }
}
