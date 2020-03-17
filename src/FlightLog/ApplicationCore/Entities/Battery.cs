using System;

namespace DukeSoftware.FlightLog.ApplicationCore.Entities
{
    public class Battery : EntityBase
    {
        public int BatteryNumber { get; set; }
        public virtual BatteryType BatteryType { get; set; }
        public bool IsActive { get; set; }
        public string Notes { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}