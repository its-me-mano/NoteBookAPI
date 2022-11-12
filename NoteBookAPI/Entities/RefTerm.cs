
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Entities
{
    public class RefTerm
    {
        [Key]
        public Guid ReftermId { get; set; }
        [Required]
        public string Types{ get; set; }
        public string Description { get; set; }
       // public ICollection<RefSet> RefSets { get; set; } = new List<RefSet>();


    }
}
