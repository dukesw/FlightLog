using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Entities
{
    public class Pilot : EntityBase
    {
        public string Name { get; set; }

        public string UserId { get; set; }
        
        public string Registration { get; set;  }

        public string Club { get; set; }

        public virtual IList<Flight> Flights { get; set; }
    }
}
