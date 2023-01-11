using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Models
{
    public class AssetDto
    {


        public Guid Id { get; set; }
        [JsonProperty(PropertyName = "field_id")]
        public Guid fieldId { get; set; }
        [JsonProperty(PropertyName = "user_id")]
        public Guid UserId { get; set; }
    }
}
