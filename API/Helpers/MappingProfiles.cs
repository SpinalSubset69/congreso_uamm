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
            CreateMap<EmailUserData, EmailUserDataDto>().ReverseMap();

            CreateMap<Student, StudentToReturnDto>()
            .ForMember(x => x.Activities, o => o.MapFrom(s => s.Activities))
            .ReverseMap();


            CreateMap<Student, StudentRegisterDto>().ReverseMap();
        }
    }
}