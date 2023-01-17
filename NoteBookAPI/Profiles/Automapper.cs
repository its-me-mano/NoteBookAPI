using AutoMapper;
using NoteBookAPI.Entities;
using NoteBookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Profiles
{
    public class Automapper : Profile
    {
        public Automapper() {

            // Address
            CreateMap<AddressCreatingDto, Entities.Address>().ForMember(
             dest => dest.Country,
             opt => opt.MapFrom(src => (Guid.Parse(src.Country)))
             ).ReverseMap();
            CreateMap<AddressUpdatingDto, Entities.Address>().ForMember(
                dest => dest.Country,
                opt => opt.MapFrom(src => (Guid.Parse(src.Country)))
            ).ForMember(
                    dest => dest.Type,
                    opt => opt.MapFrom(src => (Guid.Parse(src.Type)))
           ).ReverseMap();
            CreateMap<AddressDto, Entities.Address>().ReverseMap();


            //Asset
            CreateMap<Asset, AssetDtoCreating>().ReverseMap();
            CreateMap<Asset, AssetUpdateDto>().ReverseMap();
            CreateMap<AssetDto, Asset>().ReverseMap();


            //Email
            CreateMap<EmailCreatingDto, Email>().ForMember(
                dest => dest.TypeId,
                opt => opt.MapFrom(src => (Guid.Parse(src.type)))
            ).ReverseMap();
            CreateMap<EmailUpdatingDto, Email>().ForMember(
                dest => dest.TypeId,
                opt => opt.MapFrom(src => (Guid.Parse(src.type)))
            ).ReverseMap();
            CreateMap<EmailDto, Email>().ReverseMap();


            //Phone
            CreateMap<PhoneCreatingDto, Phone>().ForMember(
               dest => dest.TypeId,
               opt => opt.MapFrom(src => (Guid.Parse(src.type)))
           ).ReverseMap();

            CreateMap<PhoneUpdatingDto,Phone>().ForMember(
                dest => dest.TypeId,
                opt => opt.MapFrom(src => (Guid.Parse(src.type)))
            ).ReverseMap();
            CreateMap<PhoneDto,Phone>().ReverseMap();

            //Refset
            CreateMap<RefTermDto, RefTerm>().ReverseMap(); 
            CreateMap<MetaDataDto, RefSet>();

            //User
            CreateMap<UserCreatingDto, User>().ReverseMap();
            CreateMap<UserUpdatingDto, User>().ReverseMap();
            CreateMap<User,UserDto>();

        }
    }
}
