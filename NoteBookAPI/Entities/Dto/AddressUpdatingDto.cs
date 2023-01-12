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
    public class AddressUpdatingDto : BaseModelDto
    {

    
        ///<summary>
        /// street 1  of the user 
        ///</summary>
        [Required]
        [JsonProperty(PropertyName = "line1")]
        public string Line1 { get; set; }

        ///<summary>
        /// street 2 of the user 
        ///</summary>
        [JsonProperty(PropertyName = "line2")]
        public string Line2 { get; set; }

        ///<summary>
        /// city of the user 
        ///</summary>
        [Required]
        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        ///<summary>
        /// state  of the user 
        ///</summary>
        [Required]
        [JsonProperty(PropertyName = "state_name")]
        public string StateName { get; set; }


        ///<summary>
        /// zip code of the user 
        ///</summary>
        [Required]
        [JsonProperty(PropertyName = "zipcode")]
        public string Zipcode { get; set; }


        [Required]
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        ///<summary>
        /// first name of the user 
        ///</summary>
        [Required]
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

    }
}
