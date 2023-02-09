using Newtonsoft.Json;
using System;


namespace NoteBookAPI.Models
{
    public class AssetDto
    {

        ///<summary>
        ///assetDtoId
        ///</summary>
         [JsonProperty(PropertyName = "field_id")]
        public Guid Id { get; set; }

   
    }
}
