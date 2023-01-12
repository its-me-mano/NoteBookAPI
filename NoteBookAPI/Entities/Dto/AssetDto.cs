using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Models
{
    public class AssetDto
    {

        ///<summary>
        ///assetDtoId
        ///</summary>
        public Guid Id { get; set; }
        [JsonProperty(PropertyName = "field_id")]
        ///<summary>
        ///fieldId
        ///</summary>
        public Guid fieldId { get; set; }
        ///<summary>
        ///userId
        ///</summary>
        [JsonProperty(PropertyName = "user_id")]
        public Guid UserId { get; set; }
    }
}
