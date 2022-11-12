using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Models
{
    public class ImageResultDto
    {

        public Guid id { get; set; }
        public Guid FileId { get; set; }
        public string fileName { get; set; }
    }
}
