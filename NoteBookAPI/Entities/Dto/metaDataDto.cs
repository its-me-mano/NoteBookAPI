using System;
using System.Collections.Generic;
namespace NoteBookAPI.Models
{
    public class MetaDataDto
    {
        ///<summary>
        ///RefTerm Id
        ///</summary>
        public Guid Id { get; set; }
        ///<summary>
        ///Type of the metaData
        ///</summary>
        public string Types { get; set; }
        ///<summary>
        ///Description of the metadata
        ///</summary>
        public string Description { get; set; }
        ///<summary>
        ///List of refsetDto
        ///</summary>
        public ICollection<RefTermDto> RefTerms { get; set; } = new List<RefTermDto>();
    }
}
