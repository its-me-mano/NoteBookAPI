using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Models
{
    public class EmailUpdatingDto
    {
        public string email { get; set; }
        public Guid EmailId { get; set; }
        public string type { get; set; }
    }
}
