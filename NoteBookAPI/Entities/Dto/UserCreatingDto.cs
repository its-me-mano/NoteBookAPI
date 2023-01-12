using Newtonsoft.Json;
using NoteBookAPI.Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Models
{
    public class UserCreatingDto : Entities.Dto.BaseModelDto
    {
        ///<summary>
        ///First name of the user
        ///</summary>
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }
        ///<summary>
        ///last name of the user
        ///</summary>
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }
        ///<summary>
        ///password of the user
        ///</summary>
        [RegularExpression(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$", ErrorMessage = "Password must be one lower case , one upper case , special character,one number and 8 characters length")]
        public string password { get; set; }
        ///<summary>
        ///list of address
        ///</summary>
        [Required]
        public ICollection<AddressCreatingDto> Address { get; set; } = new List<AddressCreatingDto>();
        ///<summary>
        ///list of emails
        ///</summary>
        [Required]
        public ICollection<EmailCreatingDto> Emails { get; set; } = new List<EmailCreatingDto>();
        ///<summary>
        ///list of phones
        ///</summary>
        [Required]
        public ICollection<PhoneCreatingDto> Phones { get; set; } = new List<PhoneCreatingDto>();
        ///<summary>
        ///list of assets
        ///</summary>
        public ICollection<AssetDtoCreating> Assets { get; set; } = new List<AssetDtoCreating>();


    }
}
