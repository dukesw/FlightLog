using AutoMapper;
using DukeSoftware.FlightLog.Shared.Dtos;
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
            CreateMap<Account, AccountDto>();
            CreateMap<Flight, FlightDto>();
               // .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.ToString("yyyy-MM-ddTHH:mm:ssZ")));
                //.IncludeMembers(s => s.Field, s => s.Model, s => s.Pilot, s => s.Battery);
                //      .Include<Model, ModelDto>();
                //.ForMember(dest => dest.Field, opt => opt.MapFrom(src => src.Field)) // a (poor) example
                //.ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model));
            CreateMap<Location, FlightLocationDto>();
            CreateMap<Model, FlightModelDto>();
            CreateMap<Pilot, FlightPilotDto>();


            CreateMap<AccountDto, Account > ();
            CreateMap<FlightDto, Flight>()
                .ForMember(dest => dest.Model, opt => opt.Ignore())
                .ForMember(dest => dest.ModelId, opt => opt.MapFrom(src => src.Model.Id))
                .ForMember(dest => dest.Field, opt => opt.Ignore())
                .ForMember(dest => dest.FieldId, opt => opt.MapFrom(src => src.Field.Id))
                .ForMember(dest => dest.Pilot, opt => opt.Ignore())
                .ForMember(dest => dest.PilotId, opt => opt.MapFrom(src => src.Pilot.Id));
                
                //CreateMap<FlightDto, Flight>().ForMember(dest => dest.PilotId, null);

           // CreateMap<FlightDto, Flight>().ForSourceMember(src => src.Model, null); 
            //CreateMap<FlightDto, Flight>().ForSourceMember(src => src.Field, null);
            //CreateMap<FlightDto, Flight>().ForSourceMember(src => src.Pilot, null);



            CreateMap<FlightLocationDto, Location>(MemberList.None);
            CreateMap<FlightModelDto, Model>(MemberList.None);
            CreateMap<FlightPilotDto, Pilot>(MemberList.None);

            CreateMap<Location, LocationDto>();
 
            CreateMap<ModelDto, Model>()
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.ModelStatusId, opt => opt.MapFrom(src => src.Status.Id));
            
            CreateMap<ModelStatus, ModelStatusDto>();
            CreateMap<Pilot, PilotDto>();
            CreateMap<ModelStatusDto, ModelStatus>();
            CreateMap<Model, ModelDto>();
        }
    }
}
