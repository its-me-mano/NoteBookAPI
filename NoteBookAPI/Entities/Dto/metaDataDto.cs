using Newtonsoft.Json;
using System;
using System.Collections.Generic;
namespace NoteBookAPI.Models
{
    public class MetaDataDto
    {
        ///<summary>
        ///RefTerm Id
        ///</summary>
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
        ///<summary>
        ///Type of the metaData
        ///</summary>
        [JsonProperty(PropertyName = "types")]
        public string Types { get; set; }
        ///<summary>
        ///Description of the metadata
        ///</summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        ///<summary>
        ///List of refsetDto
        ///</summary>
        [JsonProperty(PropertyName = "refterms")]
        public ICollection<RefTermDto> RefTerms { get; set; } = new List<RefTermDto>();
    }
}
