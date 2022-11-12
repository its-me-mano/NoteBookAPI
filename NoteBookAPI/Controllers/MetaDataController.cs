using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NoteBookAPI.Models;
using NoteBookAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Controllers
{
    [ApiController]
    [Route("api/meta-data/ref-set")]
    public class MetaDataController : ControllerBase
    {
        private IConfiguration _config;
        private readonly IUserDetailRepositary _userDetailRepositary;
        private readonly IMapper _mapper;


        public MetaDataController(IUserDetailRepositary UserDetailRepositary, IMapper mapper, IConfiguration config)
        {
            _userDetailRepositary = UserDetailRepositary ?? throw new ArgumentNullException(nameof(UserDetailRepositary));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        [Authorize]
        [HttpGet("{number}")]
        public IActionResult refSet(int number) {
            switch (number) {
                case 1:
                    string search = "ADDRESS_TYPE";
                    var RefTermFromRepo = _userDetailRepositary.getRefTerm(search);
                    var ResultFromRepo = _userDetailRepositary.getRefSetGroup(RefTermFromRepo.ReftermId);
                    var RefSetFromRepo = _userDetailRepositary.getRefSet(ResultFromRepo);
                    var value = _mapper.Map<IEnumerable<RefSetDto>>(RefSetFromRepo);
                    metaDataDto meta = new metaDataDto();
                    meta.Description = RefTermFromRepo.Description;
                    meta.ReftermId = RefTermFromRepo.ReftermId;
                    meta.Types = RefTermFromRepo.Types;
                    meta.RefSets = value.ToList();
                    return new JsonResult(meta);
                case 2:
                    string search1 = "PHONE_NUMBER_TYPE";
                    var RefTermFromRepo1 = _userDetailRepositary.getRefTerm(search1);
                    var ResultFromRepo1 = _userDetailRepositary.getRefSetGroup(RefTermFromRepo1.ReftermId);
                    var RefSetFromRepo1 = _userDetailRepositary.getRefSet(ResultFromRepo1);
                    var value1 = _mapper.Map<IEnumerable<RefSetDto>>(RefSetFromRepo1);
                    metaDataDto meta1 = new metaDataDto();
                    meta1.Description = RefTermFromRepo1.Description;
                    meta1.ReftermId = RefTermFromRepo1.ReftermId;
                    meta1.Types = RefTermFromRepo1.Types;
                    meta1.RefSets = value1.ToList();
                    return new JsonResult(meta1);
                case 3:
                    string search2 = "EMAIL_ADDRESS_TYPE";
                    var RefTermFromRepo2 = _userDetailRepositary.getRefTerm(search2);
                    var ResultFromRepo2 = _userDetailRepositary.getRefSetGroup(RefTermFromRepo2.ReftermId);
                    var RefSetFromRepo2 = _userDetailRepositary.getRefSet(ResultFromRepo2);
                    var value2 = _mapper.Map<IEnumerable<RefSetDto>>(RefSetFromRepo2);
                    metaDataDto meta2 = new metaDataDto();
                    meta2.Description = RefTermFromRepo2.Description;
                    meta2.ReftermId = RefTermFromRepo2.ReftermId;
                    meta2.Types = RefTermFromRepo2.Types;
                    meta2.RefSets = value2.ToList();
                    return new JsonResult(meta2);
                case 4:
                    string search3 = "COUNTRY";
                    var RefTermFromRepo3 = _userDetailRepositary.getRefTerm(search3);
                    var ResultFromRepo3 = _userDetailRepositary.getRefSetGroup(RefTermFromRepo3.ReftermId);
                    var RefSetFromRepo3 = _userDetailRepositary.getRefSet(ResultFromRepo3);
                    var value3 = _mapper.Map<IEnumerable<RefSetDto>>(RefSetFromRepo3);
                    metaDataDto meta3 = new metaDataDto();
                    meta3.Description = RefTermFromRepo3.Description;
                    meta3.ReftermId = RefTermFromRepo3.ReftermId;
                    meta3.Types = RefTermFromRepo3.Types;
                    meta3.RefSets = value3.ToList();
                    return new JsonResult(meta3);
                default:
                    return NotFound();

            }
        }
    
    }
}
