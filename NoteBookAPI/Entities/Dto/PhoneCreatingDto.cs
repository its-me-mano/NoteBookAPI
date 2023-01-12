using Newtonsoft.Json;
using NoteBookAPI.Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Models
{
    public class PhoneCreatingDto : Entities.Dto.BaseModelDto
    {
        ///<summary>
        ///Phonenumber 
        ///</summary>
        [Phone(ErrorMessage = "The PhoneNumber field is not a valid phone number")]
        [Required]
        [MinLength(10)]
        [JsonProperty(PropertyName = "phone_number")]
        public string PhoneNumber { get; set; }
        ///<summary>
        ///Phone number type
        ///</summary>
        [JsonProperty(PropertyName = "type")]
        public string type { get; set; }
    }
}
