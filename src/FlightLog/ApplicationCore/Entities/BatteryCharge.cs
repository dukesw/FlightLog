﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Entities
{
    public enum ChargeType
    {
        Standard,
        Balance,
        Storage
    }

    public class BatteryCharge : EntityBase
    {
        // This may end up being a method on the Battery entity???
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public DateTime ChargedOn { get; set; }
        public ChargeType Type { get; set; }
        public int Mah { get; set; }
        public int BatteryId { get; set; }
        public Battery Battery { get; set; }
    }
}
