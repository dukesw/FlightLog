using System;


namespace DukeSoftware.FlightLog.ApplicationCore.Entities
{
    public class MaintenanceLogType : EntityBase
    {
        public string Name { get; set; }
        public int SortOrder { get; set; }
    }
}
