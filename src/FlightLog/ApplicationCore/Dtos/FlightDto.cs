using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Dtos
{
    public class FlightDto
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public int ModelFlightNumber { get; set; }
        public FlightLocationDto Field { get; set; }
        public FlightModelDto Model { get; set; }
        public int? BatteryId { get; set; }
        public FlightPilotDto Pilot { get; set; }
        public string Details { get; set; }
        // public PowerPlant FlyingOn { get; set; } // add later. Will allow tracking of the hours per engine. v2
        public float FlightMinutes { get; set; }
        //public Pilot Pilot { get; set; }  // TODO add a pilot class
        public virtual IList<MediaLinkDto> MediaLinks { get; set; }

        public int AccountId { get; set; }
    }

    public class FlightPilotDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class FlightModelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class FlightLocationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
