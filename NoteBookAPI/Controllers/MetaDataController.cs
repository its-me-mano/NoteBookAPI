using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NoteBookAPI.Contracts;
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
        private readonly IMetaDataRepositories _MetaDataRepository;
        private readonly IMapper _mapper;
        private readonly IMetaDataServices _service;
        private readonly ILogger _logger;
        public MetaDataController(IMetaDataRepositories MetaDataRepository, IMapper mapper,IMetaDataServices service,ILogger logger)
        {
            _MetaDataRepository = MetaDataRepository ?? throw new ArgumentNullException(nameof(MetaDataRepository));
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
        [HttpGet("{Key}")]
        public IActionResult RefSet([FromRoute(Name ="Key")][Required]string Key) {
            _logger.LogInformation("Search metadata initiated");
            MetaDataDto value = _service.FetchMetaData(Key);
            if (value == null)
            {
                _logger.LogError("Key not found");
                return NotFound("Key not found");
            }
            else {
                _logger.LogInformation("MetaData found successfully");
                return new JsonResult(value);
            }
        }
    
    }
}
