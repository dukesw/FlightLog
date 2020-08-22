using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Entities
{
    public class Account : EntityBase
    {
        public string Name { get; set; }
        public string OwnerId { get; set; } 
        public string OwnerEmail { get; set; }
        public DateTime OpenedOn { get; set; }
        public DateTime? ClosedOn { get; set; }
        public virtual IList<Battery> Batteries { get; set; }
        public virtual IList<BatteryCharge> BatteryCharges { get; set; }
        public virtual IList<BatteryType> BatteryTypes { get; set; }
        public virtual IList<Flight> Flights { get; set; }
        public virtual IList<Location> Fields { get; set; }
        public virtual IList<MediaLink> MediaLinks { get; set; }
        public virtual IList<Model> Models { get; set; }
        public virtual IList<Pilot> Pilots { get; set; }
        public virtual IList<PowerPlant> PowerPlants { get; set; }
    }
}
