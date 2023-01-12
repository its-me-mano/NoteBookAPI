using NoteBookAPI.Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace NoteBookAPI.Entities
{
    [DataContract]
    public class User  : BaseModel
    {
        ///<summary>
        /// first name of the user 
        ///</summary>
        [Required]
        [DataMember(Name = "first_name")]
        public string FirstName { get; set; }
        ///<summary>
        /// last name of the user 
        ///</summary>
        [DataMember(Name = "last_name")]
        public string LastName { get; set; }
        ///<summary>
        /// password of the user
        ///</summary>
        [Required]
        [DataMember(Name = "password")]
        [RegularExpression(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$", ErrorMessage = "Password must be one lower case , one upper case , special character,one number and 8 characters length")]
        public string password { get; set; }
        ///<summary>
        /// address of the user 
        ///</summary>
        [DataMember(Name = "address")]
        public ICollection<Address> Address { get; set; } = new List<Address>();
        ///<summary>
        /// email address of the user 
        ///</summary>
         [DataMember(Name = "emails")]
        public ICollection<Email> Emails { get; set; } = new List<Email>();
        ///<summary>
        /// phone number of the user 
        ///</summary>
        [DataMember(Name = "phones")]
        public ICollection<Phone> Phones { get; set; } = new List<Phone>();
        ///<summary>
        /// picuture of the user 
        ///</summary>
        [DataMember(Name = "assets")]
        public ICollection<Asset> Assets { get; set; } = new List<Asset>();
    }
}
