using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Models
{
    public class PhoneDto
    {

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        [Phone(ErrorMessage = "The PhoneNumber field is not a valid phone number")]
        [Required]
        [MinLength(10)]
        [JsonProperty(PropertyName = "phone_number")]
        public string PhoneNumber { get; set; }

        [Required]
        [JsonProperty(PropertyName = "type")]
        public Guid TypeId { get; set; }
    }
}
