using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Models
{
    public class ImageCreateDto
    {
        public Guid FileId { get; set; }
        public Guid UserId { get; set; }
        public string File { get; set; }
    }
}
