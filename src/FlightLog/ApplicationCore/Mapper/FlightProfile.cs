using AutoMapper;
using DukeSoftware.FlightLog.ApplicationCore.Dtos;
using DukeSoftware.FlightLog.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Mapper
{
    public class FlightProfile : Profile
    {
        public FlightProfile()
        {
            CreateMap<Flight, FlightDto>();
          //      .Include<Model, ModelDto>();
                //.ForMember(dest => dest.Field, opt => opt.MapFrom(src => src.Field)) // a (poor) example
                //.ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model));
            
            CreateMap<Location, LocationDto>();
            CreateMap<Model, ModelDto>();
            CreateMap<Pilot, PilotDto>();
        }
    }
}
