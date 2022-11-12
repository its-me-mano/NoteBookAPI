using AutoMapper;
using NoteBookAPI.Entities;
using NoteBookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Profiles
{
    public class AssetProfile : Profile
    {
        public AssetProfile() {
            CreateMap<AssetDto, AssetDtoCreating>().ReverseMap();
            CreateMap<AssetDto, AssetUpdateDto>().ReverseMap();
            CreateMap<AssetDto1, AssetDto>().ReverseMap();
        }
    }
}
