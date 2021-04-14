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
        public int FieldId { get; set; }
        public LocationDto Field { get; set; }
        public int ModelId { get; set; }
        public ModelDto Model { get; set; }
        public int? BatteryId { get; set; }
        public BatteryDto Battery { get; set; }

        public int PilotId { get; set; }
        public PilotDto Pilot { get; set; }
        public string Details { get; set; }
        // public PowerPlant FlyingOn { get; set; } // add later. Will allow tracking of the hours per engine. v2
        public float FlightMinutes { get; set; }
        //public Pilot Pilot { get; set; }  // TODO add a pilot class
        public virtual IList<MediaLinkDto> MediaLinks { get; set; }

        public int AccountId { get; set; }
    }
}
