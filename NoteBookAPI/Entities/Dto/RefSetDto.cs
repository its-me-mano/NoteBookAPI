using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Models
{
    public class RefSetDto
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
