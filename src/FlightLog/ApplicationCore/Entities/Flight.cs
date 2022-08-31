using System;
using System.Collections.Generic;
using System.Text;
using DukeSoftware.FlightLog.Shared.Dtos;

namespace DukeSoftware.FlightLog.ApplicationCore.Entities
{
    public class Flight : EntityBase
    {
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public DateTime Date { get; set; }
        public int ModelFlightNumber { get; set; }
        public int FieldId { get; set; }
        public Location Field { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }
        public int? BatteryId { get; set; }
        public Battery Battery { get; set; }

        public int PilotId { get; set; }
        public Pilot Pilot { get; set; }
        public string Details { get; set; }
        // public PowerPlant FlyingOn { get; set; } // add later. Will allow tracking of the hours per engine. v2
        public float FlightMinutes { get; set; }
        //public Pilot Pilot { get; set; }  // TODO add a pilot class
        public virtual IList<MediaLink> MediaLinks { get; set; }
        public virtual IList<FlightTag> Tags { get; set; } = new List<FlightTag>();
        public void CopyFrom(FlightDto flightDto)
        {
            if (flightDto != null)
            {
                // Copies the non-virtual properties to this entity, and related ids
                this.AccountId = flightDto.AccountId;
                this.Date = flightDto.Date;
                this.ModelFlightNumber = flightDto.ModelFlightNumber;
                if (flightDto.Field is not null) { this.FieldId = flightDto.Field.Id; }
                if (flightDto.Model is not null) { this.ModelId = flightDto.Model.Id; }
                this.BatteryId = flightDto.BatteryId;
                if (flightDto.Pilot is not null) { this.PilotId = flightDto.Pilot.Id; }
                this.Details = flightDto.Details;
                this.FlightMinutes = flightDto.FlightMinutes;
            }
        }
    }
}
