using Newtonsoft.Json;
using NoteBookAPI.Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Models
{
    public class UserDto 
    {
        ///<summary>
        ///UserDto Id
        ///</summary>
        public Guid Id { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [JsonProperty(PropertyName = "first_name")]
        ///<summary>
        ///user FirstName
        ///</summary>
        public string FirstName { get; set; }

        ///<summary>
        ///User LastName
        ///</summary>
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }
        ///<summary>
        ///List of addresses
        ///</summary>
        [Required]
        public ICollection<AddressDto> Address { get; set; } = new List<AddressDto>();
        ///<summary>
        ///List of emails
        ///</summary>
        [Required]
        public ICollection<EmailDto> Emails { get; set; } = new List<EmailDto>();
        ///<summary>
        ///List of phone numbers
        ///</summary>
        [Required]
        public ICollection<PhoneDto> Phones { get; set; } = new List<PhoneDto>();
        ///<summary>
        ///List of assets
        ///</summary>
        public ICollection<AssetDto> Assets { get; set; } = new List<AssetDto>();


    }
}
