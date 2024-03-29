﻿using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;


namespace NoteBookAPI.Models
{
    public class PhoneUpdatingDto
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
