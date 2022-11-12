using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Entities
{
    public class SetRefTerm
    {
        [Key]
        public Guid SetRefTermId { get; set; }
        [ForeignKey("RefSetid")]
        public Guid RefSetid { get; set; }
        [ForeignKey("ReftermId")]
        public Guid ReftermId { get; set; }

      
    }
}
