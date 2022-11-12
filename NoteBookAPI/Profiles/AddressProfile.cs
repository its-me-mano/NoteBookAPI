using AutoMapper;
using NoteBookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile() {
            CreateMap<AddressCreatingDto, Entities.Address>().ForMember(
                dest => dest.Country,
                opt => opt.MapFrom(src => (Guid.Parse(src.Country)))
            ).ReverseMap();
            CreateMap<AddressUpatingDto, Entities.Address>().ForMember(
                dest => dest.Country,
                opt => opt.MapFrom(src => (Guid.Parse(src.Country)))
            ).ForMember(
                    dest =>dest.Type,
                    opt=>opt.MapFrom(src=>(Guid.Parse(src.Type)))
           ).ReverseMap();
            CreateMap<AddressDto, Entities.Address>().ReverseMap();
        }
    }
}
