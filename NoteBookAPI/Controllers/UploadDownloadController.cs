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

namespace NoteBookAPI.Controllers
{
    [ApiController]
    [Route("api/asset")]

    public class UploadDownloadController : ControllerBase
    {
        private IConfiguration _config;
        private static IWebHostEnvironment _webHostEnvironment;

        private readonly IUserDetailRepositary _userDetailRepositary;
        private readonly IMapper _mapper;


        public UploadDownloadController(IUserDetailRepositary UserDetailRepositary, IMapper mapper, IConfiguration config, IWebHostEnvironment environment)
        {
            _userDetailRepositary = UserDetailRepositary ?? throw new ArgumentNullException(nameof(UserDetailRepositary));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _webHostEnvironment = environment ?? throw new ArgumentNullException(nameof(environment));


        }
        [Authorize]
        [HttpPost("uploadFile/{userId}")]
        public async Task<ActionResult> UploadFiles(Guid userId, [FromForm] IFormFile file)
        {
            if (file.Length < 0) 
            {
                return BadRequest();
            }
            ImageResultDto imageResultDto = new ImageResultDto();
            await using (var ms = new MemoryStream())
            {
             
                imageResultDto.fileName = file.FileName;
                imageResultDto.id = userId;

                file.CopyTo(ms);
                var fileBytes = ms.ToArray();
                ImageCreateDto imageCreateDto = new ImageCreateDto();

                imageCreateDto.File = Convert.ToBase64String(fileBytes);
                imageCreateDto.UserId = userId;
                imageCreateDto.FileId = new Guid();
                
                var ImageEntity = _mapper.Map<ImageStore>(imageCreateDto);
                _userDetailRepositary.uploadImage(ImageEntity);
                _userDetailRepositary.Save();

                AssetDtoCreating assetDtoCreating = new AssetDtoCreating();
                assetDtoCreating.fieldId = _userDetailRepositary.getAssetId(userId);
          
        
                assetDtoCreating.UserId = userId;
                if (_userDetailRepositary.CheckAsset(userId))
                {
                    var AssetFromRepo = _userDetailRepositary.GetAssetById(userId);
                    _mapper.Map(AssetFromRepo, assetDtoCreating);
                    _userDetailRepositary.UpdateAsset(AssetFromRepo);
                    _userDetailRepositary.Save();

                }
                else
                {
                    var Asset = _mapper.Map<AssetDto>(assetDtoCreating);
                    _userDetailRepositary.AddAsset(Asset);
                    _userDetailRepositary.Save();

                }
                imageCreateDto.FileId = ImageEntity.FileId;

               
                return new JsonResult(ImageEntity);
            }
          
        }
        [Authorize]
        [HttpGet("{assetId}")]
        public async Task<ActionResult> DownloadFile(string assetId)
        {

            if (assetId == null)
                return BadRequest();

            var Image64 = _userDetailRepositary.GetImage(Guid.Parse(assetId));

            var outputStream = new MemoryStream(Convert.FromBase64String(Image64.File));

            byte[] bytesInStream = outputStream.ToArray();

            return File(bytesInStream, "APPLICATION/octnet-stream");
        }


    }
}
