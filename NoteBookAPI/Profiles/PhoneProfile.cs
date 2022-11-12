using AutoMapper;
using NoteBookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Profiles
{
    public class PhoneProfile : Profile
    {
        public PhoneProfile() {
            CreateMap<PhoneCreatingDto, Entities.Phone>().ForMember(
                dest => dest.TypeId,
                opt => opt.MapFrom(src => (Guid.Parse(src.type)))
            ).ReverseMap();

            CreateMap<PhoneUpdatingDto, Entities.Phone>().ForMember(
                dest => dest.TypeId,
                opt => opt.MapFrom(src => (Guid.Parse(src.type)))
            ).ReverseMap();
            CreateMap<PhoneDto, Entities.Phone>().ReverseMap();
        }
    }
}
