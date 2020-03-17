using System.Collections.Generic;

namespace DukeSoftware.FlightLog.ApplicationCore.Entities
{
    public class BatteryType : EntityBase
    {
        public int CapacityMah { get; set; }
        public int Cells { get; set; }
        public string Type { get; set; }
        public int WeightInGrams { get; set; }
        public virtual IList<Battery> Batteries { get; set; }
    }
}