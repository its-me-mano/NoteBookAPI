using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Models
{
    public class RefSetDto
    {
   
        public string Name { get; set; }

        public Guid TypeId { get; set; }

        public string Description { get; set; }
    }
}
