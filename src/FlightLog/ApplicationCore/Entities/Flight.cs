using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Entities
{
    public class Flight : EntityBase
    {
        public DateTime Date { get; set; }
        public int Number { get; set; } 
        public Location Field { get; set; }
        public Model Model { get; set; }
        public Battery Battery { get; set; }
        public PowerPlant FlyingOn { get; set; }
        public string Footage { get; set; }
    }
}
