using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Entities
{
    public class Transmitter : EntityBase
    {
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public int PilotId { get; set; }
        public Pilot Pilot { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string SerialNumber { get; set; }
        public virtual IList<Flight> Flights { get; set; }
    }
}