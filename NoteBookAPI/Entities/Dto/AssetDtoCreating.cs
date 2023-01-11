using Newtonsoft.Json;
using NoteBookAPI.Entities.Dto;
using NoteBookAPI.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Models
{
    public class AssetDtoCreating : Entities.Dto.BaseModelDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        [JsonProperty(PropertyName = "file")]
        public string File { get; set; }
    }
}
