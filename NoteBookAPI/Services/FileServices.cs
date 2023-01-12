
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using NoteBookAPI.Contracts;
using NoteBookAPI.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Services
{
    public class FileServices : IFileServices
    {
        private readonly IFileRepositories fileRepository;
        private IConfiguration configuration;
        private readonly IMapper mapper;
        public FileServices(IFileRepositories _fileRepository, IMapper _mapper, IConfiguration _configuration)
        {
            fileRepository = _fileRepository ?? throw new ArgumentNullException(nameof(_fileRepository));
            mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
            configuration = _configuration ?? throw new ArgumentNullException(nameof(_configuration));
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
    }
}
