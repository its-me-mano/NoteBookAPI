﻿using Newtonsoft.Json;
using NoteBookAPI.Entities.Dto;
using System;

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
