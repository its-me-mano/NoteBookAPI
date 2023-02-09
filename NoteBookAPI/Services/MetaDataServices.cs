using AutoMapper;
using Microsoft.Extensions.Configuration;
using NoteBookAPI.Contracts;
using NoteBookAPI.Entities;
using NoteBookAPI.Entities.Dto;
using NoteBookAPI.Helper;
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
            RefSet refSetFromRepo = fileRepository.GetRefSet(search);
            if (refSetFromRepo == null) {
                return null;
            }
            IEnumerable<Guid> ResultFromRepo = fileRepository.GetRefTermGroup(refSetFromRepo.Id);
            IEnumerable<RefTerm> RefTermFromRepo = fileRepository.GetRefTerm(ResultFromRepo);
            IEnumerable<RefTermDto> value = mapper.Map<IEnumerable<RefTermDto>>(RefTermFromRepo);
            MetaDataDto meta = new MetaDataDto();
            meta.Description = refSetFromRepo.Description;
            meta.Id = refSetFromRepo.Id;
            meta.Types = refSetFromRepo.Key;
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
            ErrorManage errorManage = new ErrorManage();
            return errorManage.ReturningError(statuscode, description);
        }
           
        
    }
}
