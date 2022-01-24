using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Entities
{
    public class Model : EntityBase
    {
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }    // Could be Enum/Entity also.
        // TODO Create an enum for engine type; Electric, 2 Stroke Gas, 4 Stroke Gas, 2 Stroke Nitro, 4 Stroke Nitro, 4 Stroke Gas Radial
        // Simplified to a string... public PowerPlant PowerPlant { get; set; }
        public string PowerPlant { get; set; }
        public DateTime? PurchasedOn { get; set; }
        public DateTime? MaidenedOn { get; set; }
        public DateTime? DisposedOn { get; set; }
        public int ModelStatusId { get; set; }
        public ModelStatus Status { get; set; }
        public string Notes { get; set; }
        public int SortOrder { get; set; }
        public int TotalFlights { get; set; }
        public ICollection<Flight> Flights { get; }

    }
}
