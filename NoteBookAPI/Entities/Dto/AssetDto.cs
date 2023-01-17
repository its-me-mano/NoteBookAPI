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
       
/*        ///<summary>
        ///fieldId
        ///</summary>
        public string file { get; set; }
        ///<summary>
        ///userId
        ///</summary>
        [JsonProperty(PropertyName = "user_id")]
        public Guid UserId { get; set; }*/
    }
}
