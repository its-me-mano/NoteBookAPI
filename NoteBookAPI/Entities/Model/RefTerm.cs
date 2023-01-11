
using NoteBookAPI.Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Entities
{
    public class RefTerm 
    {
        ///<summary>
        /// Id of the Refterm 
        ///</summary>
        [Key]
        public Guid ReftermId { get; set; }

        ///<summary>
        /// reterm key 
        ///</summary>
        [Required]
        public string Key{ get; set; }

        ///<summary>
        /// description of the key 
        ///</summary>
        public string Description { get; set; }
  


    }
}
