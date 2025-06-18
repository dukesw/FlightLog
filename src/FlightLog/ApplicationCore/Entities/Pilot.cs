using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Entities
{
    public class Pilot : EntityBase
    {
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public string Name { get; set; }

        public string UserId { get; set; }
        
        public string Registration { get; set;  }

        public string Club { get; set; }
        public int? DefaultTransmitterId { get; set; }
        public Transmitter DefaultTransmitter { get; set; }

        public virtual IList<Flight> Flights { get; set; }
        public virtual IList<Transmitter> Transmitters { get; set; }
    }
}
