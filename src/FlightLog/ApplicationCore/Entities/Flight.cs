using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Entities
{
    public class Flight : EntityBase
    {
        public DateTime Date { get; set; }
        public int ModelFlightNumber { get; set; } 
        public int FieldId { get; set; }
        public Location Field { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }
        public int? BatteryId { get; set; }
        public Battery Battery { get; set; }

        public int PilotId { get; set; } 
        public Pilot Pilot { get; set; }
        public string Details { get; set; }
        // public PowerPlant FlyingOn { get; set; } // add later. Will allow tracking of the hours per engine. v2
        public float FlightMinutes { get; set; }
        //public Pilot Pilot { get; set; }  // TODO add a pilot class
        public virtual IList<MediaLink> MediaLinks { get; set; }
    }
}
