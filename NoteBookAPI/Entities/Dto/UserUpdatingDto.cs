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
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Letters only")]
        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Letters only")]
        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }
        [RegularExpression(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$", ErrorMessage = "Password must be one lower case , one upper case , special character,one number and 8 characters length")]
        public string password { get; set; }

        [Required]
        public ICollection<AddressUpdatingDto> Address { get; set; } = new List<AddressUpdatingDto>();
        [Required]
        public ICollection<EmailUpdatingDto> Emails { get; set; } = new List<EmailUpdatingDto>();
        [Required]
        public ICollection<PhoneUpdatingDto> Phones { get; set; } = new List<PhoneUpdatingDto>();
        public ICollection<AssetDtoCreating> Assets { get; set; } = new List<AssetDtoCreating>();

    }
}
