using NoteBookAPI.Entities.Model;
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
        ///<summary>
        /// Id of the Refset 
        ///</summary>
        [Required]  
        public string Key { get; set; }

        ///<summary>
        /// refset key
        ///</summary>
        [Key]
        public Guid Id { get; set; }

        ///<summary>
        /// description of the refset key 
        ///</summary>
        public string Description { get; set; }

    }
}
