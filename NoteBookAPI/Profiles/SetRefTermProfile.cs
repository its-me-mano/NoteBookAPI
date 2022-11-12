using AutoMapper;
using NoteBookAPI.Entities;
using NoteBookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Profiles
{
    public class SetRefTermProfile : Profile
    {
        public SetRefTermProfile() {
            CreateMap<metaDataDto, RefTerm>();
        }
    }
}
