using NoteBookAPI.Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Entities
{
    public class Phone : BaseModelDto
    {

  
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }

        ///<summary>
        /// phone number of the user
        ///</summary>
        [RegularExpression(@"^(\+\d{1,2}\s?)?1?\-?\.?\s?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$", ErrorMessage = "Enter valid phone number")]
        public string PhoneNumber { get; set; }

        ///<summary>
        /// type of phone number  
        ///</summary>
        [ForeignKey("TypeId")]
        public Guid TypeId { get; set; }
    }
}
