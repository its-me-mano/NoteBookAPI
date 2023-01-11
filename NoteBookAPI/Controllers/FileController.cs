using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Configuration;

using NoteBookAPI.Models;
using NoteBookAPI.Services;
using System;

using System.IO;

using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using NoteBookAPI.Entities;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace NoteBookAPI.Controllers
{
    [ApiController]
    [Route("api/asset")]

    public class FileController : ControllerBase
    {


        private readonly IUserDetailRepository _userDetailRepository;
        private readonly IMapper _mapper;
        private readonly IService _service;
        private readonly ILogger _logger;


        public FileController(IUserDetailRepository UserDetailRepositary, IMapper mapper,IService service,ILogger logger)
        {
            _userDetailRepository = UserDetailRepositary ?? throw new ArgumentNullException(nameof(UserDetailRepositary));
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
        [SwaggerResponse(statusCode: 400, "The user input is not valid")]
        [SwaggerResponse(statusCode: 401, "The user is not authorized")]
        [SwaggerResponse(statusCode: 500, "Internal Server Error")]
        [Authorize]
        [HttpPost("uploadFile/{user-Id}")]
        public IActionResult UploadFiles([Required][FromRoute(Name ="user-Id")]Guid userId, [FromForm] IFormFile file)
        {
            _logger.LogInformation("Uploading file is processing");
            if (file.Length < 0) 
            {
                _logger.LogError("File is not there");
                return BadRequest();
            }
            AssetDtoCreating imageCreateDto = new AssetDtoCreating();
      
                imageCreateDto.File = _service.ImageToString(file);
                Asset ImageEntity = _mapper.Map<Asset>(imageCreateDto);
                ImageEntity.UserId = userId;
            string LoggedUserId;
            if (String.IsNullOrEmpty(ClaimTypes.NameIdentifier))
            {
                LoggedUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            }
            else {
                 LoggedUserId = "6ebb437a-03e5-4ebf-83fa-652f548368f2";
                
            }
            ImageEntity.CreateBy = new Guid(LoggedUserId);
            ImageEntity.DateCreated = DateTime.Now;


                _userDetailRepository.uploadImage(ImageEntity);
                imageCreateDto.Id = ImageEntity.Id;
                 imageCreateDto.UserId = userId;
                _userDetailRepository.Save();
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
        [SwaggerResponse(statusCode: 400, "The user input is not valid")]
        [SwaggerResponse(statusCode: 401, "The user is not authorized")]
        [SwaggerResponse(statusCode: 500, "Internal Server Error")]
        [Authorize]
        [HttpGet("{asset-Id}")]
        public IActionResult DownloadFile([Required][FromRoute(Name ="asset-Id")]string assetId)
        {
            _logger.LogInformation("Downloading the image initiated");
            if (assetId == null)
            {
                _logger.LogError("AssetId is null");
                return BadRequest();
            }
            Asset Image64 = _userDetailRepository.GetImage(Guid.Parse(assetId));

            MemoryStream outputStream = new MemoryStream(Convert.FromBase64String(Image64.File));

            byte[] bytesInStream = outputStream.ToArray();
            _logger.LogInformation("File downloaded successfully");
            return File(bytesInStream, "APPLICATION/octnet-stream");

        }


    }
}
