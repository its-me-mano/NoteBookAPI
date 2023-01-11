using Newtonsoft.Json;
using NoteBookAPI.Entities.Dto;
using NoteBookAPI.Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Models
{
    public class AddressCreatingDto : Entities.Dto.BaseModelDto
    {
        [Required]
        [JsonProperty(PropertyName = "line1")]
        public string Line1 { get; set; }

        [JsonProperty(PropertyName = "line2")]
        public string Line2 { get; set; }

        [Required]
        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        [Required]
        [JsonProperty(PropertyName = "state_name")]
        public string StateName { get; set; }

        [Required]
        [JsonProperty(PropertyName = "zipcode")]
        public string Zipcode { get; set; }
        public string Type { get; set; }
        public string Country { get; set; }
       

    }
}
