    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Entities
{
    public class Phone
    {

        [Key]
        public Guid PhId { get; set; }
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public string PhoneNumber { get; set; }

        [ForeignKey("TypeId")]
        public Guid TypeId { get; set; }
    }
}
