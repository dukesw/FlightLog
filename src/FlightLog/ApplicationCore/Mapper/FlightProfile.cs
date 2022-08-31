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
            // Set up enum

            CreateMap<Account, AccountDto>();
            CreateMap<AccountDto, Account>();

            CreateMap<Location, FlightLocationDto>();
            CreateMap<FlightLocationDto, Location>(MemberList.None);

            CreateMap<Model, FlightModelDto>();
            CreateMap<FlightModelDto, Model>(MemberList.None);

            CreateMap<Pilot, FlightPilotDto>();
            CreateMap<FlightPilotDto, Pilot>(MemberList.None);

            CreateMap<Flight, FlightDto>();
            // .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.ToString("yyyy-MM-ddTHH:mm:ssZ")));
            //.IncludeMembers(s => s.Field, s => s.Model, s => s.Pilot, s => s.Battery);
            //      .Include<Model, ModelDto>();
            //.ForMember(dest => dest.Field, opt => opt.MapFrom(src => src.Field)) // a (poor) example
            //.ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model));

            CreateMap<FlightDto, Flight>()
                .ForMember(dest => dest.Model, opt => opt.Ignore())
                .ForMember(dest => dest.ModelId, opt => opt.MapFrom(src => src.Model.Id))
                .ForMember(dest => dest.Field, opt => opt.Ignore())
                .ForMember(dest => dest.FieldId, opt => opt.MapFrom(src => src.Field.Id))
                .ForMember(dest => dest.Pilot, opt => opt.Ignore())
                .ForMember(dest => dest.PilotId, opt => opt.MapFrom(src => src.Pilot.Id))
                .ForMember(dest => dest.Tags, opt => opt.Ignore());
                

            CreateMap<FlightTag, FlightTagDto>();
            CreateMap<FlightTagDto, FlightTag>();

            CreateMap<Location, LocationDto>();

            CreateMap<Model, ModelDto>();
            CreateMap<ModelDto, Model>()
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.ModelStatusId, opt => opt.MapFrom(src => src.Status.Id));

            CreateMap<ModelStatus, ModelStatusDto>();
            CreateMap<ModelStatusDto, ModelStatus>();

            CreateMap<MaintenanceLog, MaintenanceLogDto>();
            CreateMap<MaintenanceLogDto, MaintenanceLog>()
                .ForMember(dest => dest.Model, opt => opt.Ignore())
                .ForMember(dest => dest.ModelId, opt => opt.MapFrom(src => src.Model.Id))
                .ForMember(dest => dest.Type, opt => opt.Ignore())
                .ForMember(dest => dest.TypeId, opt => opt.MapFrom(src => src.Type.Id));

            CreateMap<MaintenanceLogType, MaintenanceLogTypeDto>();
            CreateMap<MaintenanceLogTypeDto, MaintenanceLogType>();
            
            CreateMap<Pilot, PilotDto>();

        }
    }
}
