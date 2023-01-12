using NoteBookAPI.Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace NoteBookAPI.Entities 
{
    [DataContract]
    public class Email : BaseModel
    {
        [ForeignKey("UserId")]
        [DataMember(Name = "user_id")]
        public Guid UserId { get; set; }
        [RegularExpression(@"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$", ErrorMessage = "enter valid email address")]

        ///<summary>
        /// Email address of the user  
        ///</summary>
        [DataMember(Name = "email_address")]
        public string EmailAddress { get; set; }

        ///<summary>
        /// type of email address 
        ///</summary>
        [ForeignKey("TypeId")]
        [DataMember(Name = "type_id")]
        public Guid TypeId { get; set; }
    }
}
