using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoteBookAPI.Models;
using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using NoteBookAPI.Entities;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using NoteBookAPI.Contracts;
using NoteBookAPI.Entities.Dto;

namespace NoteBookAPI.Controllers
{
    [ApiController]
    [Route("api/asset")]

    public class FileController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFileServices _service;
        private readonly ILogger _logger;
        public FileController(IMapper mapper,IFileServices service,ILogger logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        /// <summary>
        ///File Upload API
        /// </summary>
        /// <remarks>To upload the image or any file and then map it to an account</remarks>
        /// <param name="userId"></param>
        /// <param name="file"></param>
        /// <response code="200">Floor layout image and tab file info returned successfully</response>
        /// <response code="400">The user input is not valid.</response>
        /// <response code="401">The user is not authorized.</response>
        /// <response code="500">Internal Server Error</response>
        [SwaggerOperation("UploadImage")]
        [SwaggerResponse(statusCode: 201, "Success!")]
        [SwaggerResponse(statusCode: 400, "The user input is not valid", typeof(ErrorDto))]
        [SwaggerResponse(statusCode: 401, "The user is not authorized", typeof(ErrorDto))]
        [SwaggerResponse(statusCode: 500, "Internal Server Error", typeof(ErrorDto))]
        [Authorize]
        [HttpPost("uploadFile/{user-Id}")]
        public IActionResult UploadFiles([Required][FromRoute(Name ="user-Id")]Guid userId, [FromForm] IFormFile file)
        {
            string loggedUserId= User.FindFirstValue(ClaimTypes.NameIdentifier); 
            _logger.LogInformation("Uploading file is processing");
            if (file.Length < 0) 
            {
                _logger.LogError("File is not there");
                return StatusCode(400, _service.ErrorToReturn("400", "There is no file"));
            }
            AssetDtoCreating imageCreateDto = new AssetDtoCreating();
            imageCreateDto.File = _service.ImageToString(file);
            Asset imageEntity = _mapper.Map<Asset>(imageCreateDto);
            imageEntity.UserId = userId;
            imageEntity.CreateBy = new Guid(loggedUserId);
            imageEntity.DateCreated = DateTime.Now;
            imageEntity.File = imageCreateDto.File;
            _service.SaveImage(imageEntity); 
            imageCreateDto.Id = imageEntity.Id;
            imageCreateDto.UserId = userId;          
            _logger.LogInformation("File uploaded successfully");
            return new JsonResult(imageCreateDto);
            }
        /// <summary>
        ///Download API
        /// </summary>
        /// <remarks>To get the file object and it can be used </remarks>
        /// <param name="assetId"></param>
        /// <response code="200">Floor layout image and tab file info returned successfully</response>
        /// <response code="400">The user input is not valid.</response>
        /// <response code="401">The user is not authorized.</response>
        /// <response code="500">Internal Server Error</response>
        [SwaggerOperation("DownloadImage")]
        [SwaggerResponse(statusCode: 201, "Success!")]
        [SwaggerResponse(statusCode: 400, "The user input is not valid", typeof(ErrorDto))]
        [SwaggerResponse(statusCode: 401, "The user is not authorized", typeof(ErrorDto))]
        [SwaggerResponse(statusCode: 500, "Internal Server Error", typeof(ErrorDto))]
        [Authorize]
        [HttpGet("{asset-id}")]
        public IActionResult DownloadFile([Required][FromRoute(Name ="asset-id")]string assetId)
        {
            _logger.LogInformation("Downloading the image initiated");
            if (assetId == null)
            {
                _logger.LogError("AssetId is null");
                return StatusCode(404, _service.ErrorToReturn("404", "AssetId is null"));
            }
            Asset image = _service.GetImage(assetId);    
            MemoryStream outputStream = new MemoryStream(Convert.FromBase64String(image.File));
            byte[] bytesInStream = outputStream.ToArray();
            _logger.LogInformation("File downloaded successfully");
            return File(bytesInStream, "APPLICATION/octnet-stream");
        }


    }
}
