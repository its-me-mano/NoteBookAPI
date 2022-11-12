using AutoMapper;
using NoteBookAPI.Entities;
using NoteBookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Profiles
{
    public class RefSetProfile : Profile
    {
        public RefSetProfile() {
            CreateMap<RefSetDto, RefSet>().ReverseMap();
        }
    }
}
