using Newtonsoft.Json;
using NoteBookAPI.Entities.Dto;
using System;

namespace NoteBookAPI.Models
{
    public class AssetUpdateDto 
    {
        ///<summary>
        ///Asset Id
        ///</summary>
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
    }
}
