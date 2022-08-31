using DukeSoftware.FlightLog.Shared.Dtos;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DukeSoftware.FlightLog.ApplicationCore.Entities
{
    public class MaintenanceLog : EntityBase
    {
        public int AccountId { get; set; }
        public DateTime Date { get; set; }
        public string Details { get; set; }
        public Model Model { get; set; }
        public int ModelId { get; set; }
        public MaintenanceLogType Type { get; set; }
        public int TypeId { get; set; }
    }
}
