using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Models
{
    public class EmailDto
    {

        public Guid UserId { get; set; }
        public Guid EmailId { get; set; }
        public string email { get; set; }
        public Guid TypeId { get; set; }
    }
}
