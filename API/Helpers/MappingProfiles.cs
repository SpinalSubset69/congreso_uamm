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
            CreateMap<Participant, ParticipantToReturnDto>()
            .ForMember(x => x.Career, o => o.MapFrom(s => s.Career.Name))
            .ReverseMap();
        }
    }
}