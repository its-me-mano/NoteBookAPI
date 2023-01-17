using AutoMapper;
using Microsoft.Extensions.Configuration;
using NoteBookAPI.Contracts;
using NoteBookAPI.Entities;
using NoteBookAPI.Entities.Dto;
using NoteBookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NoteBookAPI.Services
{
    public class MetaDataServices : IMetaDataServices
    {

        private readonly IMetaDataRepositories fileRepository;
        private IConfiguration configuration;
        private readonly IMapper mapper;
        public MetaDataServices(IMetaDataRepositories _fileRepository, IMapper _mapper, IConfiguration _configuration)
        {
            fileRepository = _fileRepository ?? throw new ArgumentNullException(nameof(_fileRepository));
            mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
            configuration = _configuration ?? throw new ArgumentNullException(nameof(_configuration));
        }
        ///<summary>
        /// find the key from the metadata 
        ///</summary>
        ///<param name="key"></param> 
        public MetaDataDto FetchMetaData(string search)
        {
            RefSet RefSetFromRepo = fileRepository.getRefSet(search);
            if (RefSetFromRepo == null) {
                return null;
            }
            IEnumerable<Guid> ResultFromRepo = fileRepository.getRefTermGroup(RefSetFromRepo.Id);
            IEnumerable<RefTerm> RefTermFromRepo = fileRepository.getRefTerm(ResultFromRepo);
            IEnumerable<RefTermDto> value = mapper.Map<IEnumerable<RefTermDto>>(RefTermFromRepo);
            MetaDataDto meta = new MetaDataDto();
            meta.Description = RefSetFromRepo.Description;
            meta.Id = RefSetFromRepo.Id;
            meta.Types = RefSetFromRepo.Key;
            meta.RefTerms = value.ToList();
            return meta;
        }
        ///<summary>
        ///Return Error in the format
        ///</summary>
        ///<param name="description"></param>
        ///<param name="statuscode"></param>
        public ErrorDto ErrorToReturn(string statuscode, string description)
        {
            ErrorDto Response = new ErrorDto();
            if (statuscode == "404")
            {
                Response.Message = "Not Found";
            }
            else if (statuscode == "400")
            {
                Response.Message = "Bad Request";
            }
            else if (statuscode == "401")
            {
                Response.Message = "Unauthorized";
            }
            else if (statuscode == "500")
            {
                Response.Message = "Internal server error";
            }
            else if (statuscode == "409")
            {
                Response.Message = "Conflict";
            }
            Response.StatusCode = statuscode;
            Response.Description = description;
            return Response;
        }
    }
}
