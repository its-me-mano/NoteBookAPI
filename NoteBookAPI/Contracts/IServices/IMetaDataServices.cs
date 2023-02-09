using NoteBookAPI.Entities.Dto;
using NoteBookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Contracts
{
    public interface IMetaDataServices 
    {
        ///<summary>
        /// find the key from the metadata 
        ///</summary>
        ///<param name="key"></param>
        MetaDataDto FetchMetaData(string key);

        ///<summary>
        ///Return Error in the format
        ///</summary>
        ///<param name="description"></param>
        ///<param name="statuscode"></param>
        ErrorDto ErrorToReturn(string statuscode, string description);
    }
}
