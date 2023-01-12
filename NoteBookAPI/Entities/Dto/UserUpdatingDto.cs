using Newtonsoft.Json;
using NoteBookAPI.Entities.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Models
{
    public class UserUpdatingDto : BaseModelDto
    {
        ///<summary>
        ///User FirstName
        ///</summary>
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Letters only")]
        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        ///<summary>
        ///User LastName
        ///</summary>
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Letters only")]
        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }
        ///<summary>
        ///user password
        ///</summary>
        [RegularExpression(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$", ErrorMessage = "Password must be one lower case , one upper case , special character,one number and 8 characters length")]
        public string password { get; set; }

        ///<summary>
        ///list of address
        ///</summary>
        [Required]
        public ICollection<AddressUpdatingDto> Address { get; set; } = new List<AddressUpdatingDto>();
        ///<summary>
        ///list of email 
        ///</summary>
        [Required]
        public ICollection<EmailUpdatingDto> Emails { get; set; } = new List<EmailUpdatingDto>();
        ///<summary>
        ///list of phone
        ///</summary>
        [Required]
        public ICollection<PhoneUpdatingDto> Phones { get; set; } = new List<PhoneUpdatingDto>();
        ///<summary>
        /// list of assetDto
        ///</summary>
        public ICollection<AssetDtoCreating> Assets { get; set; } = new List<AssetDtoCreating>();

    }
}
