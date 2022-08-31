using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DukeSoftware.FlightLog.ApplicationCore.Entities
{
    public class FlightTag : EntityBase
    {
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public IList<Flight> Flights { get; set; }
    }
}
