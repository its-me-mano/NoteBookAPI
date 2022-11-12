using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Models
{
    public class PhoneDto
    {

        public Guid PhId { get; set; }
        public Guid UserId { get; set; }
        public string PhoneNumber { get; set; }
        public Guid TypeId { get; set; }
    }
}
