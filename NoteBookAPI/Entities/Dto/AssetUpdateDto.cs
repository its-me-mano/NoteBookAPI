using Newtonsoft.Json;
using NoteBookAPI.Entities.Dto;
using NoteBookAPI.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Models
{
    public class AssetUpdateDto : BaseModelDto
    {
        ///<summary>
        ///Asset Id
        ///</summary>
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
    }
}
