using NoteBookAPI.Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Entities 
{
    public class Email : BaseModelDto
    {
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        [RegularExpression(@"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$", ErrorMessage = "enter valid email address")]

        ///<summary>
        /// Email address of the user  
        ///</summary>
        public string EmailAddress { get; set; }

        ///<summary>
        /// type of email address 
        ///</summary>
        [ForeignKey("TypeId")]
        public Guid TypeId { get; set; }
    }
}
