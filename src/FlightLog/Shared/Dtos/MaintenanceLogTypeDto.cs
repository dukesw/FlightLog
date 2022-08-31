using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DukeSoftware.FlightLog.Shared.Dtos
{
    public class MaintenanceLogTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }
    }
}
