using Newtonsoft.Json;
using System;
namespace NoteBookAPI.Models
{
    public class RefTermDto
    {
        ///<summary>
        ///RefSetId key
        ///</summary>
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }
        ///<summary>
        ///Refset Id
        ///</summary>
        public Guid Id { get; set; }
        ///<summary>
        ///Description
        ///</summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }
}
