using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Entities
{
    public class Model : EntityBase
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }    // Could be Enum/Entity also.
        // TODO Create an enum for engine type; Electric, 2 Stroke Gas, 4 Stroke Gas, 2 Stroke Nitro, 4 Stroke Nitro, 4 Stroke Gas Radial
        public PowerPlant PowerPlant { get; set; }
        
        public DateTime PurchasedOn { get; set; }
        public DateTime MaidenedOn { get; set; }
        public string Notes { get; set; }

    }
}
