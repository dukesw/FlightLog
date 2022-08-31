using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DukeSoftware.FlightLog.Shared.Dtos
{
    public class MaintenanceLogDto
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public DateTime Date { get; set; }
        public string Details { get; set; }
        public ModelDto Model { get; set; }
        public MaintenanceLogTypeDto Type { get; set; }
    }
}
