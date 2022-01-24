using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.Shared.Dtos
{
    public class ModelStatusDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
