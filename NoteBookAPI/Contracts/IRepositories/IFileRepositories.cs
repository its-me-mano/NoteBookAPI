using NoteBookAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Contracts
{
    public interface IFileRepositories
    {
        ///<summary>
        /// save the file  
        ///</summary>
        bool Save();
        ///<summary>
        /// upload the image  
        ///</summary>
        ///<param name="img"></param>
        public void UploadImage(Asset img);
        ///<summary>
        /// get the image
        ///</summary>
        ///<param name="id"></param>
        public Asset GetImage(Guid id);
    }
}
