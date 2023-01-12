using Newtonsoft.Json;
using NoteBookAPI.Entities.Dto;
using NoteBookAPI.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Models
{
    public class AssetDtoCreating :BaseModelDto
    {
        ///<summary>
        ///assetDto Id
        ///</summary>
        public Guid Id { get; set; }
        ///<summary>
        ///userId
        ///</summary>
        public Guid UserId { get; set; }
        ///<summary>
        ///File
        ///</summary>
        [JsonProperty(PropertyName = "file")]
        public string File { get; set; }
    }
}
