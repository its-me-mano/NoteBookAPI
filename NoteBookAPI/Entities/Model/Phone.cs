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
    public class Phone : BaseModel
    {
        [ForeignKey("UserId")]
        [DataMember(Name = "user_id")]
        public Guid UserId { get; set; }
        ///<summary>
        /// phone number of the user
        ///</summary>
        [DataMember(Name = "phone_number")]
        [RegularExpression(@"^(\+\d{1,2}\s?)?1?\-?\.?\s?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$", ErrorMessage = "Enter valid phone number")]
        public string PhoneNumber { get; set; }   
        ///<summary>
        ///type id of the phone
        ///</summary>
        [DataMember(Name="type_id")]
        [ForeignKey("TypeId")]
        public Guid TypeId { get; set; }
    }
}
