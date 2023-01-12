using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Contracts
{
    public interface IFileServices
    {
        ///<summary>
        /// convert the image to string
        ///</summary>
        ///<param name="file"></param>
        string ImageToString(IFormFile file);
        ///<summary>
        /// convert the string to image  
        ///</summary>
        ///<param name="assetId"></param>
        byte[] StringToImage(String assetId);
    }
}
