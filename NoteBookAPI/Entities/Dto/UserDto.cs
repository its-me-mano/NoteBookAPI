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
        public Guid Id { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }

        [Required]
        public ICollection<AddressDto> Address { get; set; } = new List<AddressDto>();
        [Required]
        public ICollection<EmailDto> Emails { get; set; } = new List<EmailDto>();
        [Required]
        public ICollection<PhoneDto> Phones { get; set; } = new List<PhoneDto>();
        public ICollection<AssetDto> Assets { get; set; } = new List<AssetDto>();


    }
}
