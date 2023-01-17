using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;


namespace NoteBookAPI.Models
{
    public class PhoneDto
    {
        ///<summary>
        ///Phone number Id
        ///</summary>
        public Guid Id { get; set; }
        ///<summary>
        ///User Id
        ///</summary>
        public Guid UserId { get; set; }
        ///<summary>
        ///Phone number
        ///</summary>
        [Phone(ErrorMessage = "The PhoneNumber field is not a valid phone number")]
        [Required]
        [MinLength(10)]
        [JsonProperty(PropertyName = "phone_number")]
        public string PhoneNumber { get; set; }

        ///<summary>
        ///Phone number type
        ///</summary>
        [Required]
        [JsonProperty(PropertyName = "type")]
        public Guid TypeId { get; set; }
    }
}
