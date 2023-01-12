using AutoMapper;
using Microsoft.Extensions.Configuration;
using NoteBookAPI.Contracts;
using NoteBookAPI.Entities;
using NoteBookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            RefTerm RefTermFromRepo = fileRepository.getRefTerm(search);
            if (RefTermFromRepo == null) {
                return null;
            }
            IEnumerable<Guid> ResultFromRepo = fileRepository.getRefSetGroup(RefTermFromRepo.Id);
            IEnumerable<RefSet> RefSetFromRepo = fileRepository.getRefSet(ResultFromRepo);
            IEnumerable<RefSetDto> value = mapper.Map<IEnumerable<RefSetDto>>(RefSetFromRepo);
            MetaDataDto meta = new MetaDataDto();
            meta.Description = RefTermFromRepo.Description;
            meta.ReftermId = RefTermFromRepo.Id;
            meta.Types = RefTermFromRepo.Key;
            meta.RefSets = value.ToList();
            return meta;
        }
    }
}
