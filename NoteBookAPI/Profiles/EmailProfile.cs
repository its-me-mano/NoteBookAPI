using AutoMapper;
using NoteBookAPI.Models;
using System;

namespace NoteBookAPI.Profiles
{
    public class EmailProfile : Profile
    {

        public EmailProfile(){

            CreateMap<EmailCreatingDto, Entities.Email>().ForMember(
                dest => dest.TypeId,
                opt => opt.MapFrom(src => (Guid.Parse(src.type)))
            ).ReverseMap();
            CreateMap<EmailUpdatingDto, Entities.Email>().ForMember(
                dest => dest.TypeId,
                opt => opt.MapFrom(src => (Guid.Parse(src.type)))
            ).ReverseMap();
            CreateMap<EmailDto, Entities.Email>().ReverseMap();
        }
       
    }
}
