using Newtonsoft.Json;
using System;


namespace NoteBookAPI.Models
{
    public class AssetDtoCreating 
    {
        ///<summary>
        ///assetDto Id
        ///</summary>
        [JsonProperty(PropertyName = "asset_id")]
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
