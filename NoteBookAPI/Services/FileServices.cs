using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using NoteBookAPI.Contracts;
using NoteBookAPI.Entities;
using NoteBookAPI.Entities.Dto;
using NoteBookAPI.Helper;
using System;
using System.IO;


namespace NoteBookAPI.Services
{
    public class FileServices : IFileServices
    {
        private readonly IFileRepositories fileRepository;
        private IConfiguration configuration;
        private readonly IMapper mapper;
        private readonly IUserServices _userservice;
        public FileServices(IFileRepositories _fileRepository, IMapper _mapper, IConfiguration _configuration,IUserServices userservice)
        {
            fileRepository = _fileRepository ?? throw new ArgumentNullException(nameof(_fileRepository));
            mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
            configuration = _configuration ?? throw new ArgumentNullException(nameof(_configuration));
            _userservice = userservice;
        }
        ///<summary>
        /// convert the image to string
        ///</summary>
        ///<param name="file"></param>
        public string ImageToString(IFormFile file)
        {
            MemoryStream ms = new MemoryStream();
            file.CopyTo(ms);
            byte[] fileBytes = ms.ToArray();
            return (Convert.ToBase64String(fileBytes));
        }
        ///<summary>
        /// convert the string to image  
        ///</summary>
        ///<param name="assetId"></param>
        public byte[] StringToImage(String assetId)
        {
            Asset Image64 = fileRepository.GetImage(Guid.Parse(assetId));

            MemoryStream outputStream = new MemoryStream(Convert.FromBase64String(Image64.File));

            byte[] bytesInStream = outputStream.ToArray();
            return bytesInStream;
        }
        ///<summary>
        ///Return Error in the format
        ///</summary>
        ///<param name="description"></param>
        ///<param name="statuscode"></param>
        public ErrorDto ErrorToReturn(string statuscode, string description)
        {
            return _userservice.ErrorToReturn(statuscode, description);
        }
        /// <summary>
        /// Saving the image in the database
        /// </summary>
        /// <param name="ImageEntity"></param>
        public void SaveImage(Asset ImageEntity) {
            fileRepository.UploadImage(ImageEntity);
            fileRepository.Save();
        }
      
        /// <summary>
        /// Get the image in the database
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns></returns>
        public Asset GetImage(string assetId) {
            return fileRepository.GetImage(Guid.Parse(assetId));
        }
    }
}
