using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Models
{
    public class MetaDataDto
    {
        ///<summary>
        ///RefTerm Id
        ///</summary>
        public Guid ReftermId { get; set; }
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
        public ICollection<RefSetDto> RefSets { get; set; } = new List<RefSetDto>();
    }
}
