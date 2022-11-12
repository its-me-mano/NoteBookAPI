using AutoMapper;
using NoteBookAPI.Models;


namespace NoteBookAPI.Profiles
{
    public class FileProfile : Profile
    {
        public FileProfile() {

            CreateMap<ImageCreateDto, Entities.ImageStore>().ReverseMap();
        }
    }
}
