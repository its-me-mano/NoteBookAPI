using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Models
{
    public class metaDataDto
    {
    
        public Guid ReftermId { get; set; }
        public string Types { get; set; }
        public string Description { get; set; }
        public ICollection<RefSetDto> RefSets { get; set; } = new List<RefSetDto>();
    }
}
