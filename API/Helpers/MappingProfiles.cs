using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using Core.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Activity, ActivityToReturnDto>()
            .ForMember(x => x.Rapportuers, o => o.MapFrom(s => s.Rapportuers))                        
            .ForMember(x => x.Attendees, o => o.MapFrom(s => s.Attendees)); 
            
            CreateMap<Activity, ActivityWithNoAttendeesToReturnDto>();
            

            CreateMap<Attendee, AttendeeToReturnDto>()            
            .ForMember(x => x.Activities, o => o.MapFrom(s => s.Activities));

            CreateMap<Attendee, AtendeeWithNoActivitiesToReturnDto>();             
            
            CreateMap<Attendee, RegisterDto>().ReverseMap();
            CreateMap<Rapportuer, RegisterRepportuerDto>().ReverseMap();

            CreateMap<Rapportuer, RapportuerToReturnDto>();
        }
    }
}