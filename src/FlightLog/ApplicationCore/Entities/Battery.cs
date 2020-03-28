using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DukeSoftware.FlightLog.ApplicationCore.Entities
{
    public class Battery : EntityBase
    {
        public int BatteryNumber { get; set; }
        public int BatteryTypeId { get; set; }
        public virtual BatteryType BatteryType { get; set; }
        public bool IsActive { get; set; }
        public string Notes { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}