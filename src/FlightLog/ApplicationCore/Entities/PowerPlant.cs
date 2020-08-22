using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Entities
{
    public enum PowerPlantType
    {
        Electric, 
        TwoStrokeNitro, 
        FourStrokeNitro, 
        TwoStrokeGas, 
        FourStrokeGas, 
        Unpowered
    }

    public class PowerPlant : EntityBase
    {
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public string Name { get; set; }
        public PowerPlantType Type { get; set; }
        public string Manufacturer { get; set; }
        public DateTime PurchasedOn { get; set; }
        public string Notes { get; set; }
    }
}
