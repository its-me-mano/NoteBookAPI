using Newtonsoft.Json;
using NoteBookAPI.Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Models
{
    public class PhoneUpdatingDto : Entities.Dto.BaseModelDto
    {
        ///<summary>
        ///PhoneNumber
        ///</summary>
        [Phone(ErrorMessage = "The PhoneNumber field is not a valid phone number")]
        [Required]
        [MinLength(10)]
        [JsonProperty(PropertyName = "phone_number")]
        public string PhoneNumber { get; set; }
        ///<summary>
        ///Phone Number type
        ///</summary>
        [Required]
        [JsonProperty(PropertyName = "type")]
        public string type { get; set; }
        ///<summary>
        ///Phone Id
        ///</summary>
        public Guid Id { get; set; }
    }
}
