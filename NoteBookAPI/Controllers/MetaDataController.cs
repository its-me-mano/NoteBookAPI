using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NoteBookAPI.Entities;
using NoteBookAPI.Models;
using NoteBookAPI.Services;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Controllers
{
    [ApiController]
    [Route("api/meta-data/ref-set")]
    public class MetaDataController : ControllerBase
    {
        private IConfiguration _config;
        private readonly IUserDetailRepository _userDetailRepositary;
        private readonly IMapper _mapper;
        private readonly IService _service;
        private readonly ILogger _logger;

        public MetaDataController(IUserDetailRepository UserDetailRepositary, IMapper mapper,IService service,ILogger logger)
        {
            _userDetailRepositary = UserDetailRepositary ?? throw new ArgumentNullException(nameof(UserDetailRepositary));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            
        }


        /// <summary>
        /// Metadata API
        /// </summary>
        /// <remarks>To get the metadata list like Address Type, Email address type, phone number type, country</remarks>
        /// <param name="searchKey"></param>
        /// <response code="200">Success</response>
        /// <response code="404">NotFound</response>
        /// <response code="400">The user input is not valid.</response>
        /// <response code="401">The user is not authorized.</response>
        /// <response code="500">Internal Server Error</response>
        [SwaggerOperation("Metadata API")]
        [SwaggerResponse(statusCode: 200, "Success!")]
        [SwaggerResponse(statusCode: 400, "The user input is not valid")]
        [SwaggerResponse(statusCode: 401, "The user is not authorized")]
        [SwaggerResponse(statusCode: 404, "The user  is not found")]
        [SwaggerResponse(statusCode: 500, "Internal Server Error")]
        [Authorize]
        [HttpGet("{search-Key}")]
        public IActionResult refSet([FromRoute(Name ="search-Key")][Required]string searchKey) {
            _logger.LogInformation("Search metadata initiated");
            metaDataDto value = _service.MetaData(searchKey);
            if (value == null)
            {
                _logger.LogError("searchkey not found");
                return NotFound();
            }
            else {
                _logger.LogInformation("MetaData found successfully");
                return new JsonResult(value);
            }
        }
    
    }
}
