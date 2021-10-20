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
        public MappingProfiles(){
            CreateMap<Activity, ActivityToReturnDto>()
            .ForMember(x => x.Rapportuer, o => o.MapFrom(s => s.Rapportuer.Name))
            .ForMember(x => x.Career, o => o.MapFrom(s => s.Career.Name))
            .ForMember(x => x.ActivityType, o => o.MapFrom(s => s.ActivityType.Name))
            .ForMember(x => x.Attendees, o => o.MapFrom(s => s.Attendees));

            CreateMap<Attendee, AttendeeToReturnDto>()
            .ForMember(x => x.Career, o => o.MapFrom(s => s.Career.Name))
            .ForMember(x => x.Activity, o => o.MapFrom(s => s.Activity.Name));

            CreateMap<Attendee, RegisterDto>().ReverseMap();
        }
    }
}