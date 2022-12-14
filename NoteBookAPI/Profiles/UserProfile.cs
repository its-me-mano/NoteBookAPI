using AutoMapper;
using System;


namespace NoteBookAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() {
            CreateMap<Models.UserCreatingDto,Entities.User>().ReverseMap();
            CreateMap<Models.UserUpdatingDto,Entities.User>().ReverseMap();
            CreateMap<Entities.User, Models.UserDto>();
            
        }

    }
}
