using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Entities
{
    public class Email
    {
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        [Key]
        public Guid EmailId { get; set; }
        public string email { get; set; }


        [ForeignKey("TypeId")]
        public Guid TypeId { get; set; }
    }
}
