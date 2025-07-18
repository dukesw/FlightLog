using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DukeSoftware.FlightLog.Shared.Dtos
{
    public class FlightDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Flight date is required")]
        public DateTime? Date { get; set; }
        public int ModelFlightNumber { get; set; }
        [Required(ErrorMessage = "Field is required")]
        public FlightLocationDto Field { get; set; }
        [Required(ErrorMessage = "Model is required")]
        public FlightModelDto Model { get; set; }
        public int? BatteryId { get; set; }
        [Required(ErrorMessage = "Pilot is required")] 
        public FlightPilotDto Pilot { get; set; }
        public string Details { get; set; }
        // public PowerPlant FlyingOn { get; set; } // add later. Will allow tracking of the hours per engine. v2
        [Required(ErrorMessage = "Flight time is required")]
        [Range(1, int.MaxValue, ErrorMessage ="Flight time must be greater than 0 minutes")]
        public float FlightMinutes { get; set; }
        //public Pilot Pilot { get; set; }  // TODO add a pilot class
        public virtual IList<MediaLinkDto> MediaLinks { get; set; }

        public virtual IList<FlightTagDto> Tags { get; set; }


        public int AccountId { get; set; }

        public FlightDto()
        {
            Field = new FlightLocationDto();
            Model = new FlightModelDto();
            Pilot = new FlightPilotDto();
            Tags = new List<FlightTagDto>();
            MediaLinks = new List<MediaLinkDto>();
        }
    }

    public class FlightPilotDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class FlightModelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class FlightLocationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
