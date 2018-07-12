﻿using System;

namespace DukeSoftware.FlightLog.ApplicationCore.Entities
{
    public class Battery : EntityBase
    {
        public BatteryType BatteryType { get; set; }
        public bool IsActive { get; set; }
        public string Notes { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}