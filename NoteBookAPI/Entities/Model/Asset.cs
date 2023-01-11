using NoteBookAPI.Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Entities
{
    public class Asset : BaseModelDto
    {
   
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }

        ///<summary>
        /// binary array of the image
        ///</summary>
        [Required]
        [MaxLength]
        public string File { get; set; }

    }
}
