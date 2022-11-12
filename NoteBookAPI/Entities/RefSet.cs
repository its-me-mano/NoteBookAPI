using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Entities
{
    public class RefSet
    {
        [Required]  
        public string Name { get; set; }
        [Key]
        public Guid TypeId { get; set; }

        public string Description { get; set; }

    }
}
