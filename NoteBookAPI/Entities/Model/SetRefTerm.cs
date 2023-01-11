using NoteBookAPI.Entities.Model;
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
        ///<summary>
        /// Id of the SetRefTerm 
        ///</summary>
        [Key]
        public Guid SetRefTermId { get; set; }

        [ForeignKey("RefSetid")]
        ///<summary>
        /// refset Id 
        ///</summary>
        public Guid RefSetid { get; set; }


        ///<summary>
        /// refterm id 
        ///</summary>
        [ForeignKey("ReftermId")]
        public Guid ReftermId { get; set; }

      
    }
}
